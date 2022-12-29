using AStar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PathManager : MonoSingleton<PathManager>
{
    AStar.AStar aStar;
    private SO_GridProperties gridProperties;

    private void OnEnable()
    {
        EventCenter.Instance.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnNextSceneLoad);
    }

    private void OnNextSceneLoad()
    {
        gridProperties = GridPropertiesManager.Instance.GetActiveSceneGridProperties();

        aStar = new AStar.AStar(
gridProperties.gridWidth,
gridProperties.gridHeight,
gridProperties.originX,
gridProperties.originY
);

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
        EventCenter.Instance?.Unregister(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), OnNextSceneLoad);
    }

    public Stack<Vector2Int> CalculatePath(Vector2Int startPos, Vector2Int endPos)
    {
        aStar.SetStartPos(startPos);
        aStar.SetEndPos(endPos);
        var path = aStar.CalculatePath(out var findPath);
        return OutputPath(path, findPath);
    }

    public void SetStartPos(Vector2Int startPos)
    {
        aStar.SetStartPos(startPos);
    }

    public Stack<Vector2Int> OutputPath(Stack<Node> nodes, bool found)
    {
        Stack<Vector2Int> result = new Stack<Vector2Int>();
        while (nodes != null && nodes.Count > 0)
        {
            Node curNode = nodes.Pop();
            result.Push(curNode.pos + new Vector2Int(aStar.originalX, aStar.originalY));
        }
        return result;
    }

    public void SetEndPos(Vector2Int endPos)
    {
        aStar.SetEndPos(endPos);
    }
}
