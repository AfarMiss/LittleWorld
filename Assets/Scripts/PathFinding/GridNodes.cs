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
            nodes = new Node[width, height];
        }

        public Node GetNode(int x, int y)
        {
            return (nodes[x, y]);
        }

        public void SetObstacle(int x, int y)
        {
            nodes[x, y].isObstacle = true;
        }
    }
}
