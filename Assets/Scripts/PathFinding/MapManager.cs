using LittleWorld;
using LittleWorld.MapUtility;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public List<Map> maps;
    private Map colonyMap;
    public Map curDisplayMap;
    public Map ColonyMap => colonyMap;

    private MapManager()
    {
    }
    public Queue<Vector2Int> CreateNewPath(Vector3 startPos, Vector3 endPos)
    {
        return colonyMap.CalculatePath(startPos, endPos);
    }
    public override void OnCreateInstance()
    {
        base.OnCreateInstance();
        EventCenter.Instance.Register<MainMapInfo>(EventEnum.START_NEW_GAME.ToString(), InitMainMaps);
    }

    private void InitMainMaps(MainMapInfo mainMapInfo)
    {
        colonyMap = new Map(Map.GetMapSize(mainMapInfo.size), mainMapInfo.seed);
        MapRenderManager.Instance.RenderMap(colonyMap);
        curDisplayMap = colonyMap;
    }
}

public class MainMapInfo
{
    public string seed;
    public MapSize size;

    public MainMapInfo(string seed, string size = "MEDIUM")
    {
        this.seed = seed;
        if (Enum.TryParse(typeof(MapSize), size, out var result))
        {
            this.size = (MapSize)result;
        }
        else
        {
            this.size = MapSize.MEDIUM;
        }
    }
}
