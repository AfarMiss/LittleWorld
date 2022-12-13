using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniBase
{
    public class DirectionHelper
    {
        public static Vector3Int JudgeDir(Vector3 center, Vector3 point)
        {
            var offset = point - center;
            if ((offset.y >= offset.x && offset.x >= 0) || (offset.y >= -offset.x && offset.x <= 0))
            {
                return Vector3Int.up;
            }
            else if ((offset.y <= offset.x && offset.x <= 0) || (offset.y <= -offset.x && offset.x >= 0))
            {
                return Vector3Int.down;
            }
            else if ((offset.y < offset.x && offset.y >= 0) || (offset.y > -offset.x && offset.y <= 0))
            {
                return Vector3Int.right;
            }
            else if ((offset.y > offset.x && offset.y <= 0) || (offset.y < -offset.x && offset.y >= 0))
            {
                return Vector3Int.left;
            }
            else
            {
                return Vector3Int.zero;
            }
        }
    }
}
