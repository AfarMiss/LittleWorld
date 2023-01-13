using AStar;
using LittleWorld;
using LittleWorld.Interface;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalPathManager : Singleton<GlobalPathManager>, IObserveSceneChange
{
    private Grid mapGrid;
    public bool Initialized => initialized;
    private bool initialized = false;
    AStar.AStar aStar;
    private SO_GridProperties gridProperties;

    private GlobalPathManager()
    {
    }

    public Vector3Int WorldToCell(Vector3 worldPos)
    {
        return mapGrid.WorldToCell(worldPos);
    }

    public Vector3 CellToWorld(Vector3Int cellPos)
    {
        return mapGrid.CellToWorld(cellPos);
    }

    public Queue<Vector2Int> CreateNewPath(Vector3 startPos, Vector3 endPos)
    {
        var endCellPos = WorldToCell(endPos);
        var startCellPos = WorldToCell(startPos);

        return GlobalPathManager.Instance.CalculatePath(
            new Vector2Int(startCellPos.x, startCellPos.y),
            new Vector2Int(endCellPos.x, endCellPos.y)
            );

    }

    public override void Initialize()
    {
        base.Initialize();
        EventCenter.Instance.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), InitMapInfo);

        ObserveChangeSceneRegister();
    }

    private void InitMapInfo()
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

        initialized = true;
    }

    public Queue<Vector2Int> CalculatePath(Vector2Int startPos, Vector2Int endPos)
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

    public Queue<Vector2Int> OutputPath(Stack<Node> nodes, bool found)
    {
        Queue<Vector2Int> result = new Queue<Vector2Int>();
        while (nodes != null && nodes.Count > 0)
        {
            Node curNode = nodes.Pop();
            result.Enqueue(curNode.pos + new Vector2Int(aStar.originalX, aStar.originalY));
        }
        return result;
    }

    public void SetEndPos(Vector2Int endPos)
    {
        aStar.SetEndPos(endPos);
    }

    public void AfterSceneLoad()
    {
        mapGrid = GameObject.FindObjectOfType<Grid>();
    }

    public void BeforeSceneUnload()
    {
    }

    public void ObserveChangeSceneRegister()
    {
        Root.Instance.ObserveSceneChanges.Add(this);
    }

    public void ObserveChangeSceneUnregister()
    {
        Root.Instance.ObserveSceneChanges.Remove(this);
    }
}
