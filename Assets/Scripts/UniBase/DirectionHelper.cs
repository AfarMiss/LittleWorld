using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniBase
{
    public class DirectionHelper
    {
        public static Vector2Int JudgeDir(Vector2 center, Vector2 point)
        {
            var offset = point - center;
            if ((offset.y >= 2 * offset.x && offset.x >= 0) || (offset.y >= -2 * offset.x && offset.x <= 0))
            {
                return Vector2Int.up;
            }
            else if ((offset.y <= 2 * offset.x && offset.x <= 0) || (offset.y <= -2 * offset.x && offset.x >= 0))
            {
                return Vector2Int.down;
            }
            else if ((offset.y < 2 * offset.x && offset.y >= 0) || (offset.y > -2 * offset.x && offset.y <= 0))
            {
                return Vector2Int.right;
            }
            else if ((offset.y > 2 * offset.x && offset.y <= 0) || (offset.y < -2 * offset.x && offset.y >= 0))
            {
                return Vector2Int.left;
            }
            else
            {
                return Vector2Int.zero;
            }
        }

        public static Face JudgeDirFace(Vector3 origin, Vector3 lookto)
        {
            var offset = lookto - origin;
            if ((offset.y >= 2 * offset.x && offset.x >= 0) || (offset.y >= -2 * offset.x && offset.x <= 0))
            {
                return Face.Up;
            }
            else if ((offset.y <= 2 * offset.x && offset.x <= 0) || (offset.y <= -2 * offset.x && offset.x >= 0))
            {
                return Face.Down;
            }
            else if ((offset.y < 2 * offset.x && offset.y >= 0) || (offset.y > -2 * offset.x && offset.y <= 0))
            {
                return Face.Right;
            }
            else if ((offset.y > 2 * offset.x && offset.y <= 0) || (offset.y < -2 * offset.x && offset.y >= 0))
            {
                return Face.Left;
            }
            else
            {
                Debug.LogError($"unconsidered case:offset.x:{offset.x},offset.y:{offset.y}");
                return Face.Up;
            }
        }
    }
}
