using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Vector3IntExtension
{
    public static Vector3Int ToVector3Int(this Vector3 vector)
    {
        return new Vector3Int((int)vector.x, (int)vector.y, (int)vector.z);
    }
}
