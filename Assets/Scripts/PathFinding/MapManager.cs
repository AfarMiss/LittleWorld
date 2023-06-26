using LittleWorld;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    private List<Map> _maps;
    private Map _colonyMap;
    public Map curDisplayMap;
    public Map ColonyMap => _colonyMap;
    public Vector2Int mapSize;

    private MapManager()
    {
    }
    public Queue<Vector2Int> CreateNewPath(Vector2 startPos, Vector2 endPos)
    {
        return _colonyMap.CalculatePath(startPos, endPos);
    }

    public void InitMainMaps(MainMapInfo mainMapInfo)
    {
        _colonyMap = new Map(Map.GetMapSize(mainMapInfo.size), mainMapInfo.seed);
        curDisplayMap = _colonyMap;

        _colonyMap.GenerateInitObjects();
        MapRenderManager.Instance.RenderMap(_colonyMap);
    }

    public override void Dispose()
    {
        base.Dispose();
        MapRenderManager.Instance.Dispose();
    }
}

public class MainMapInfo
{
    public string seed;
    public MapSize size;

    public MainMapInfo(string seed, MapSize size)
    {
        this.seed = seed;
        this.size = size;
    }
}
