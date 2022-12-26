using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;

namespace AStar
{
    public class AStar
    {
        public Node startNode;
        public Node endNode;
        public int mapWidth;
        public int mapHeight;

        public GridNodes gridNodes;

        public List<Node> openList;
        public List<Node> closeList;

        public Stack<Node> CalculatePath(out bool findPath)
        {
            findPath = false;

            openList = new List<Node>();
            closeList = new List<Node>();

            gridNodes = new GridNodes(mapWidth, mapHeight);
            startNode.gCost = 0;
            startNode.hCost = GetHCost(startNode, endNode);

            openList.Add(startNode);

            while (openList.Count > 0)
            {
                openList.Sort();
                var currentNode = openList[0];
                closeList.Add(currentNode);
                openList.RemoveAt(0);

                if (currentNode == endNode)
                {
                    findPath = true;
                    return RetrievePath(closeList);
                }
                else
                {
                    EvaluateNeighbour(currentNode);
                    return null;
                }
            }
            return null;
        }

        public Stack<Node> RetrievePath(List<Node> closedNodes)
        {
            var result = new Stack<Node>();
            result.Push(closedNodes[closedNodes.Count - 1]);
            var curNode = closedNodes[closedNodes.Count - 1];
            var parentIndex = GetParentIndex(closedNodes, curNode);

            while (parentIndex > 0)
            {
                parentIndex = GetParentIndex(closedNodes, curNode);
                result.Push(closedNodes[parentIndex]);
                curNode = closedNodes[parentIndex];
                closedNodes.RemoveAt(parentIndex);
            }

            return result;

        }

        private int GetParentIndex(List<Node> closedNodes, Node curNode)
        {
            var indexResult = -1;
            for (indexResult = 0; indexResult < closedNodes.Count; indexResult++)
            {
                if (curNode.parent == closedNodes[indexResult])
                {
                    break;
                }
            }
            return indexResult;
        }

        public float GetHCost(Node start, Node end)
        {
            return Vector2Int.Distance(start.pos, new Vector2Int(end.pos.x, start.pos.y))
                                 + Vector2Int.Distance(new Vector2Int(end.pos.x, start.pos.y), end.pos);
        }

        public void EvaluateNeighbour(Node currentNode)
        {
            for (int i = currentNode.pos.x - 1; i <= currentNode.pos.x + 1; i++)
            {
                for (int j = currentNode.pos.y - 1; j <= currentNode.pos.y + 1; j++)
                {
                    if (i == currentNode.pos.x && j == currentNode.pos.y)
                    {
                        continue;
                    }

                    var curEvaluate = gridNodes.GetNode(i, j);

                    if (!curEvaluate.isObstacle)
                    {
                        if (!openList.Contains(curEvaluate))
                        {
                            openList.Add(curEvaluate);
                        }
                        else
                        {
                            var tempCurEvaluate = new Node(new Vector2Int(i, j), curEvaluate.isObstacle);
                            tempCurEvaluate.gCost = curEvaluate.gCost + Vector2Int.Distance(new Vector2Int(i, j), curEvaluate.pos);
                            tempCurEvaluate.hCost = GetHCost(tempCurEvaluate, endNode);
                            tempCurEvaluate.parent = currentNode;
                            if (tempCurEvaluate.FCost < curEvaluate.FCost)
                            {
                                curEvaluate = tempCurEvaluate;
                            }
                        }
                    }
                }
            }
        }
    }
}

