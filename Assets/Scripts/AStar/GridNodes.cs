using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AStar
{
    public class GridNodes
    {
        public Node[,] nodes;

        public GridNodes(int height, int width)
        {
            nodes = new Node[height, width];
        }

        public Node GetNode(int x, int y)
        {
            return (nodes[y, x]);
        }
    }
}
