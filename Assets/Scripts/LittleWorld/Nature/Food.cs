using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Object
{
    public class Food : WorldObject
    {
        public float nutrition;
        public Food(Vector3Int gridPos) : base(gridPos)
        {
        }
    }
}
