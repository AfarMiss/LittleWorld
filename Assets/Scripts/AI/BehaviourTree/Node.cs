using FlowCanvas.Nodes;
using LittleWorld;
using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static AI.MoveLeaf;

namespace AI
{
    public class Node
    {
        public enum Status { SUCCESS, RUNNING, FAILURE }
        public Status status = Status.RUNNING;
        public List<Node> children = new List<Node>();
        public int currentChildIndex = -1;
        public string name;
        public Node root;

        public Node()
        {

        }

        protected Node(string n)
        {
            name = n;
        }

        public virtual void AddChild(Node n)
        {
            if (currentChildIndex == -1)
            {
                currentChildIndex = 0;
            }
            children.Add(n);
        }

        struct NodeLevel
        {
            public int level;
            public Node node;

        }

        /// <summary>
        /// 运行时重置
        /// </summary>
        protected virtual void RunningReset()
        {
            if (currentChildIndex != -1)
            {
                currentChildIndex = 0;
            }
            foreach (var item in children)
            {
                item.RunningReset();
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
                return Status.FAILURE;
            }
            if (!animal.IsMoving || (animal.IsMoving && animal.CurDestination.HasValue && animal.CurDestination.Value != destination))
            {
                animal.GoToLoc(destination, moveType);
                Debug.Log($"{animal.ItemName}_{animal.instanceID}重新计算路径for{destination}");
            }
            if (animal.GridPos == destination)
            {
                return Node.Status.SUCCESS;
            }
            return Node.Status.RUNNING;
        }
    }
}
