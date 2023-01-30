using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Berries : Food
    {
        public Berries(Vector3Int gridPos) : base(gridPos)
        {
            nutrition = 0.05f;
        }
    }
}
