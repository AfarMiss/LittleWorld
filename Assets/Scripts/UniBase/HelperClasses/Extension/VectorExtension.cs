using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class VectorExtension
{
    public static Vector3Int ToVector3Int(this Vector3 vector)
    {
        return new Vector3Int((int)vector.x, (int)vector.y, (int)vector.z);
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

    public static Vector2 ToWorldVector2(this Vector3 worldVector)
    {
        return new Vector2(worldVector.x, worldVector.y);
    }
}
