using LittleWorld;
using LittleWorld.Item;
using System.Collections.Generic;
using UnityEngine;
using static AI.MoveLeaf;

namespace AI
{
    public class Node
    {
        public enum Status
        {
            ///<summary>The operation has failed.</summary>
            Failure = 0,
            ///<summary>The operation has succeeded.</summary>
            Success = 1,
            ///<summary>The operation is still running.</summary>
            Running = 2,
            ///<summary>Indicates a "ready" state. No operation is performed yet.</summary>
            Resting = 3,
            ///<summary>The operation encountered an error. Usually execution error. This status is unhandled and is neither considered Success nor Failure.</summary>
            Error = 4,
            ///<summary>The operation is considered optional and is neither Success nor Failure.</summary>
            Optional = 5,
        }
        public Status status = Status.Running;
        public List<Node> children = new List<Node>();
        public int currentChildIndex = -1;
        public string name;
        public Node parent;
        protected int priority;
        protected NodeGraph graph;
        public bool IsDirty;
        public Blackboard Blackboard => graph?.blackboard;

        //所有没有指定容器和黑板的节点都会被放在默认容器和黑板中。
        public static Blackboard deafaultBlackboard = new Blackboard();
        public static NodeGraph defaultGraph = new NodeGraph(deafaultBlackboard);

        public virtual int Priority
        {
            get
            {
                return priority;
            }
            set
            {
                //先这么写，以后改
                if (parent is PSelector)
                {
                    parent.IsDirty = true;
                }
                priority = value;
            }
        }

        public Node()
        {
            this.name = "NonNameNode";
            this.priority = 0;
            this.graph = defaultGraph;
        }

        public Node(string n, NodeGraph graph = null, int priortiy = 0)
        {
            this.name = n;
            this.Priority = priortiy;
            if (graph != null)
            {
                this.graph = graph;
            }
            else
            {
                this.graph = defaultGraph;
            }
        }

        public virtual void AddChild(Node n)
        {
            if (currentChildIndex == -1)
            {
                currentChildIndex = 0;
            }
            if (n.graph != this.graph)
            {
                n.graph = this.graph;
            }
            children.Add(n);
            n.parent = this;
        }

        public virtual void RemoveChild(Node n)
        {
            var nodeIndex = children.IndexOf(n);
            children.Remove(n);
            if (currentChildIndex == nodeIndex)
            {
                currentChildIndex = -1;
                Reset();
            }
            n.parent = null;
        }

        /// <summary>
        /// 运行时重置
        /// </summary>
        protected virtual void Reset()
        {
            if (children.Count > 0)
            {
                currentChildIndex = 0;
            }
            foreach (var item in children)
            {
                item.Reset();
            }
        }

        public virtual Status Process()
        {
            return children[currentChildIndex].Process();
        }

        public static Node.Status GoToLoc(Vector2Int destination, Animal animal, MoveType moveType)
        {
            if (!Current.CurMap.GetGrid(destination).isLand)
            {
                Debug.LogWarning("目标点不是陆地，无法到达！");
                return Status.Failure;
            }
            if (!animal.IsMoving || (animal.IsMoving && animal.CurDestination.HasValue && animal.CurDestination.Value != destination))
            {
                animal.GoToLoc(destination, moveType);
                Debug.Log($"{animal.ItemName}_{animal.instanceID}重新计算路径for{destination}");
            }
            if (animal.GridPos == destination)
            {
                return Node.Status.Success;
            }
            return Node.Status.Running;
        }
    }
}
