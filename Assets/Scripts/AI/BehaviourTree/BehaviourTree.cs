using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AI
{
    public class BehaviourTree : Node
    {
        public BehaviourTree()
        {
            name = "BehaviourTree";
        }

        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public void SetVariable(string key, object value)
        {
            dataContext[key] = value;
        }

        public bool HasChildren => children.Count > 0;


        public object GetVariable(string key)
        {
            if (dataContext.TryGetValue(key, out var value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public BehaviourTree(string n)
        {
            name = n;
        }

        public override Status Process()
        {
            if (currentChildIndex >= children.Count)
            {
                Debug.LogError("状态越界:" + this.name);
                return Status.Failure;
            }
            if (currentChildIndex < 0)
            {
                Debug.LogWarning("空树:" + this.name);
                return Status.Failure;
            }
            return children[currentChildIndex].Process();
        }

        struct NodeLevel
        {
            public Node node;
            public int level;
        }

        public void PrintTree()
        {
            string treePrintout = "";
            Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();
            Node currentNode = this;
            nodeStack.Push(new NodeLevel { level = 0, node = currentNode });

            while (nodeStack.Count != 0)
            {
                NodeLevel nextNode = nodeStack.Pop();
                treePrintout += $"{new string('-', nextNode.level)}{nextNode.node.name}\n";
                foreach (var child in nextNode.node.children)
                {
                    nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = child });
                }
            }

            Debug.Log(treePrintout);
        }
    }

}
