using System.Collections;
using System.Collections.Generic;
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

    public static Vector2 ToScreenPos(this Vector2 worldVector)
    {
        return Camera.main.WorldToScreenPoint(worldVector);
    }

    public static Vector2 ToWorldVector2(this Vector3Int worldVector)
    {
        return new Vector2(worldVector.x, worldVector.y);
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
}
