using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;

namespace AStar
{
    public class AStar
    {
        public int originalX;
        public int originalY;
        public Node startNode;
        public Node endNode;
        public int mapWidth;
        public int mapHeight;

        public GridNodes gridNodes;

        public List<Node> openList;
        public List<Node> closeList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startNode">起始点</param>
        /// <param name="endNode">终点</param>
        /// <param name="mapWidth">横向边长度</param>
        /// <param name="mapHeight">纵向边长度</param>
        public AStar(int mapWidth, int mapHeight, int originalX, int originalY)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.originalX = originalX;
            this.originalY = originalY;
            gridNodes = new GridNodes(mapHeight, mapWidth);

            //填入数据
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    gridNodes.nodes[j, i] = new Node(new Vector2Int(j, i), false);
                }
            }
        }

        public void ClearLastValue()
        {
            //填入数据
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    gridNodes.nodes[j, i].ClearLastValue();
                }
            }
        }

        public void SetStartPos(Vector2Int startNode)
        {
            this.startNode = gridNodes.GetNode(startNode.x - originalX, startNode.y - originalY);
        }

        public void SetEndPos(Vector2Int endNode)
        {
            this.endNode = gridNodes.GetNode(endNode.x - originalX, endNode.y - originalY);
        }

        public Stack<Node> CalculatePath(out bool findPath)
        {
            findPath = false;

            ClearLastValue();

            openList = new List<Node>();
            closeList = new List<Node>();

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

        public void OutputPath(Stack<Node> nodes, bool found)
        {
            Debug.Log($"===================OutputPath");
            Debug.Log($"path found:{found}");
            while (nodes != null && nodes.Count > 0)
            {
                var curNode = nodes.Pop();
                Debug.Log($"curNode.pos:{curNode.pos}");
            }
            Debug.Log($"===================OutputPathEnd");
        }

        private int GetParentIndex(List<Node> closedNodes, Node curNode)
        {
            var indexResult = 0;
            for (; indexResult < closedNodes.Count; indexResult++)
            {
                if (curNode.parent == closedNodes[indexResult])
                {
                    break;
                }
            }
            if (indexResult < closedNodes.Count)
            {
                return indexResult;
            }
            else
            {
                return -1;
            }
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
                    if (i < 0 || i >= mapWidth || j < 0 || j >= mapHeight)
                    {
                        continue;
                    }

                    var curEvaluate = gridNodes.GetNode(i, j);
                    if (closeList.Contains(curEvaluate))
                    {
                        continue;
                    }

                    if (!curEvaluate.isObstacle)
                    {
                        var tempCurEvaluate = curEvaluate;
                        tempCurEvaluate.gCost = currentNode.gCost + Vector2Int.Distance(new Vector2Int(i, j), currentNode.pos);
                        tempCurEvaluate.hCost = GetHCost(tempCurEvaluate, endNode);
                        tempCurEvaluate.parent = currentNode;

                        if (!openList.Contains(curEvaluate))
                        {
                            curEvaluate = tempCurEvaluate;
                            openList.Add(curEvaluate);
                        }
                        else
                        {
                            if (tempCurEvaluate.FCost < curEvaluate.FCost)
                            {
                                curEvaluate = tempCurEvaluate;
                            }
                        }
                    }
                }
            }
        }

        public void SetObstacle(int x, int y)
        {
            gridNodes.SetObstacle(x - originalX, y - originalY);
        }
    }
}

