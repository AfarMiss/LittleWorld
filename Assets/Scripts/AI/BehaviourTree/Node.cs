using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTreeUtility
{
    public class Node
    {
        public enum Status { SUCCESS, RUNNING, FAILURE }
        public Status status;
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

        public static Node.Status GoToLoc(Vector2Int destination, Humanbeing human)
        {
            if (human.motion == Humanbeing.MotionStatus.Idle)
            {
                human.GoToLoc(destination);
                human.motion = Humanbeing.MotionStatus.Running;
            }
            if (human.GridPos == destination)
            {
                human.motion = Humanbeing.MotionStatus.Idle;
                return Node.Status.SUCCESS;
            }
            return Node.Status.RUNNING;
        }
    }
}
