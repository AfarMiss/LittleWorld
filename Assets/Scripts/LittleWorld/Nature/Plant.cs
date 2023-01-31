using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Plant : WorldObject
    {
        /// <summary>
        /// 修建工作量
        /// </summary>
        public int cutWorkAmount;
        public Plant(Vector2Int gridPos) : base(gridPos)
        {
        }
    }
}

