using LittleWorld;
using LittleWorld.MapUtility;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPathManager : Singleton<GlobalPathManager>
{
    public List<Map> maps;
    private Map mainMap;
    public Map MainMap => mainMap;

    private GlobalPathManager()
    {
    }
    public Queue<Vector2Int> CreateNewPath(Vector3 startPos, Vector3 endPos)
    {
        return mainMap.CalculatePath(startPos, endPos);
    }
    public override void OnCreateInstance()
    {
        base.OnCreateInstance();
        EventCenter.Instance.Register<MainMapInfo>(EventEnum.START_NEW_GAME.ToString(), InitMainMaps);
    }

    private void InitMainMaps(MainMapInfo mainMapInfo)
    {
        mainMap = new Map(Map.GetMapSize(mainMapInfo.size), mainMapInfo.seed);
        MapRenderManager.Instance.RenderMap(mainMap);
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
