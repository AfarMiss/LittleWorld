using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStar
{
    public class Node : IComparable<Node>
    {
        public Vector2Int pos;
        public bool isObstacle;
        public float gCost;
        public float hCost;

        public Node parent;
        public float FCost => gCost + hCost;

        public Node(Vector2Int pos, bool isObstacle)
        {
            this.pos = pos;
            this.isObstacle = isObstacle;
        }

        public void ClearLastValue()
        {
            this.parent = null;
            gCost = 0;
            hCost = 0;
        }

        public int CompareTo(Node other)
        {
            var compareF = this.FCost.CompareTo(other.FCost);
            if (compareF == 0)
            {
                compareF = this.hCost.CompareTo(other.hCost);
            }
            return compareF;
        }
    }
}

