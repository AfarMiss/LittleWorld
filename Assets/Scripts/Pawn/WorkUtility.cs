using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.WorkUtility
{
    public static class WorkUtility
    {
        public static Vector3Int GetRandomWorkAroundPoint(Vector3Int target)
        {
            Vector2Int[] randomPosOffset = {
                new Vector2Int(-1,-1),
                new Vector2Int(-1,0),
                new Vector2Int(-1,1),
                new Vector2Int(0,-1),
                new Vector2Int(0,1),
                new Vector2Int(1,-1),
                new Vector2Int(1,0),
                new Vector2Int(1,1)
            };
            var resultRef = randomPosOffset[Random.Range(0, 8)];

            return new Vector3Int(resultRef.x, resultRef.y, 0) + target;
        }

        public static void ItemsDrop()
        {

        }
    }
}
