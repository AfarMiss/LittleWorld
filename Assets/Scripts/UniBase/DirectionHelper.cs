using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHelper
{
    public static Vector3 JudgeDir(Vector3 center, Vector3 point)
    {
        var offset = point - center;
        if ((offset.y >= offset.x && offset.x > 0) || (offset.y >= -offset.x && offset.x < 0))
        {
            return Vector3.up;
        }
        else if ((offset.y <= offset.x && offset.x < 0) || (offset.y <= -offset.x && offset.x > 0))
        {
            return Vector3.down;
        }
        else if ((offset.y < offset.x && offset.y > 0) || (offset.y > -offset.x && offset.y < 0))
        {
            return Vector3.right;
        }
        else if ((offset.y > offset.x && offset.y < 0) || (offset.y < -offset.x && offset.y > 0))
        {
            return Vector3.left;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
