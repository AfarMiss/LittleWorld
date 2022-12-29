using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    AStar.AStar aStar;
    [SerializeField]
    private Vector2Int startPos;
    [SerializeField]
    private Vector2Int endPos;
    private SO_GridProperties gridProperties;

    private void OnEnable()
    {
        EventCenter.Instance.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnNextSceneLoad);
    }

    private void OnNextSceneLoad()
    {
        gridProperties = GridPropertiesManager.Instance.GetActiveSceneGridProperties();

        aStar = new AStar.AStar(
startPos,
endPos,
gridProperties.gridWidth,
gridProperties.gridHeight);

        foreach (var grid in gridProperties.gridPropertyList)
        {
            if (grid.gridBoolProperty == GridBoolProperty.isNPCObstacle)
            {
                aStar.SetObstacle(grid.gridCoordinate.x, grid.gridCoordinate.y);
            }
        }
    }

    private void OnDisable()
    {
        EventCenter.Instance.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnNextSceneLoad);
    }

    private void CalculatePath()
    {
        var path = aStar.CalculatePath(out var findPath);
        aStar.OutputPath(path, findPath);
    }
}
