using AStarUtility;
using LittleWorld;
using LittleWorld.Interface;
using LittleWorld.MapUtility;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalPathManager : Singleton<GlobalPathManager>
{
    private Grid mapGrid;
    public Map curMap;
    public string seed;

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

        var originalData = curMap.CalculatePath(
            new Vector2Int(startCellPos.x, startCellPos.y),
            new Vector2Int(endCellPos.x, endCellPos.y)
            );
        originalData.TryDequeue(out var path);
        Debug.Log(string.Concat($"startPos: {startPos},startCellPos:{startCellPos},",
             originalData.Count > 0 ? $"firstPathPoint:{originalData.TryPeek(out var firstPathPoint)}" : ""));
        return originalData;
    }

    public override void Initialize()
    {
        base.Initialize();
        EventCenter.Instance.Register(EventEnum.AFTER_NEXT_SCENE_LOAD.ToString(), InitAllMaps);
    }

    private void InitAllMaps()
    {
        curMap = new Map(new Vector2Int(100, 100), seed);
    }
}
