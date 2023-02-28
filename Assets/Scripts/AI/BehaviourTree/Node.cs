using FlowCanvas.Nodes;
using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.WalkLeaf;

namespace AI
{
    public class Node
    {
        public enum Status { SUCCESS, RUNNING, FAILURE }
        public Status status = Status.RUNNING;
        public List<Node> children = new List<Node>();
        public int currentChild = 0;
        public string name;
        public Node root;

        public Node()
        {

        }

        public Node(string n)
        {
            name = n;
        }

        public void AddChild(Node n)
        {
            children.Add(n);
        }

        struct NodeLevel
        {
            public int level;
            public Node node;

        }

        public virtual Status Process()
        {
            return children[currentChild].Process();
        }

        public static Node.Status GoToLoc(Vector2Int destination, Animal animal, MoveType moveType)
        {
            if (!animal.IsMoving || (animal.IsMoving && animal.CurDestination.HasValue && animal.CurDestination.Value != destination))
            {
                animal.GoToLoc(destination, moveType);
                Debug.Log("重新计算路径for" + destination);
            }
            if (animal.GridPos == destination)
            {
                return Node.Status.SUCCESS;
            }
            return Node.Status.RUNNING;
        }
    }
}
