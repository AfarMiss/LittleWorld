using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAStar : MonoBehaviour
{
    AStar.AStar aStar;

    private void Start()
    {
        aStar = new AStar.AStar(
    new Vector2Int(0, 0),
    new Vector2Int(4, 0),
    10, 10);
        aStar.OutputPath(aStar.CalculatePath(out var findPath));
    }
}
