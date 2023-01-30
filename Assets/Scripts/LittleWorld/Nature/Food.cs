using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Food : WorldObject
    {
        public float nutrition;
        public Food(Vector3Int gridPos) : base(gridPos)
        {
        }
    }
}
