using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Message
{
    public class ChangeGridMessage
    {
        public Vector2Int lastPos;
        public WorldObject wo;

        public ChangeGridMessage(Vector2Int lastPos, WorldObject wo)
        {
            this.lastPos = lastPos;
            this.wo = wo;
        }
    }
}
