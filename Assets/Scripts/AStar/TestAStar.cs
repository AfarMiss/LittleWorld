using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAStar : MonoBehaviour
{
    AStar.AStar aStar;

    private void Start()
    {
        aStar = new AStar.AStar(
    new Vector2Int(1, 0),
    new Vector2Int(1, 4),
    5, 6);
        aStar.SetObstacle(1, 0);
        aStar.SetObstacle(1, 1);
        aStar.SetObstacle(1, 2);
        aStar.SetObstacle(1, 3);
        aStar.SetObstacle(1, 4);
        var path = aStar.CalculatePath(out var findPath);
        aStar.OutputPath(path, findPath);
    }
}
