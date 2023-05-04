using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Ammunition : Thing
    {
        public AmmunitionInfo AmmunitionInfo;
        public Ammunition(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
        }
    }
}
