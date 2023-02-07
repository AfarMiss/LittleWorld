using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public static class VectorExtension
{
    public static Vector3Int ToCell(this Vector3 vector)
    {
        return new Vector3Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), Mathf.FloorToInt(vector.z));
    }

    public static Vector2Int ToCell(this Vector2 vector)
    {
        return new Vector2Int(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y));
    }

    public static Vector3Int To3(this Vector2Int vector2)
    {
        return new Vector3Int(vector2.x, vector2.y, 0);
    }

    public static Vector3 ToFloat(this Vector3Int vector3)
    {
        return new Vector3(vector3.x, vector3.y, vector3.z);
    }

    public static Vector3 To3(this Vector2 vector2)
    {
        return new Vector3(vector2.x, vector2.y, 0);
    }

    public static Vector2Int To2(this Vector3Int vector3)
    {
        return new Vector2Int(vector3.x, vector3.y);
    }

    public static Vector2 ToScreenPos(this Vector2 worldVector)
    {
        return Camera.main.WorldToScreenPoint(worldVector);
    }

    public static Vector2 ToWorldVector2(this Vector3Int worldVector)
    {
        return new Vector2(worldVector.x, worldVector.y);
    }

    public static Vector2Int ClampInMap(this Vector2Int gridPos, Map map)
    {
        Vector2Int mapStart = map.MapLeftBottomPoint;
        Vector2Int mapSize = map.MapSize;
        gridPos.Clamp(mapStart, mapStart + mapSize - Vector2Int.one);
        return gridPos;
    }

    public static Vector3 ClampInMap(this Vector3 gridPos, Map map)
    {
        Vector2Int mapStart = map.MapLeftBottomPoint;
        Vector2Int mapSize = map.MapSize;
        var vec2GridPos = gridPos.ToCell().To2();
        vec2GridPos.Clamp(mapStart, mapStart + mapSize - Vector2Int.one);
        return vec2GridPos.To3();
    }

    public static Vector2Int ToWorldVector2Int(this Vector3Int worldVector)
    {
        return new Vector2Int(worldVector.x, worldVector.y);
    }

    public static bool InGrid(this Vector2 curPos, Vector2Int refPos)
    {
        return curPos.ToCell() == refPos;
    }

    public static Vector2 ToWorldVector2(this Vector3 worldVector)
    {
        return new Vector2(worldVector.x, worldVector.y);
    }

    public static bool InStraightLine(this Vector2Int thisPoint, Vector3Int refPoint)
    {
        return thisPoint.x == refPoint.x || thisPoint.y == refPoint.y;
    }

    public static bool InStraightLine(this Vector2Int thisPoint, Vector2Int refPoint)
    {
        return thisPoint.x == refPoint.x || thisPoint.y == refPoint.y;
    }
}
