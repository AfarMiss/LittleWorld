using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.WalkLeaf;

namespace LittleWorld.Path
{
    public class PathInfo
    {
        public Queue<Vector2Int> curPath;
        public MoveType moveType;

        public PathInfo(Queue<Vector2Int> curPath, MoveType moveType)
        {
            this.curPath = curPath;
            this.moveType = moveType;
        }

        public PathInfo()
        {
            this.curPath = new Queue<Vector2Int>();
            this.moveType = MoveType.idle;
        }

        public static float GetSpeedRatio(MoveType? moveType)
        {
            switch (moveType)
            {
                case MoveType.wander:
                    return 0.3f;
                case MoveType.walk:
                    return 1f;
                case MoveType.dash:
                    return 1.4f;
                case MoveType.idle:
                    return 0f;
                case null:
                    return 0f;
                default:
                    return 1f;
            }
        }
    }
}
