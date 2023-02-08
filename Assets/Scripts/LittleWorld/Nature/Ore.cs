using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Ore : WorldObject
    {
        public OreInfo oreInfo;
        public int curHitPoint;

        public Ore(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            if (ObjectConfig.oreInfo.TryGetValue(itemCode, out oreInfo))
            {
                oreInfo = ObjectConfig.oreInfo[itemCode];
                ItemName = oreInfo.itemName;
            }
        }

        public override Sprite GetSprite()
        {
            return oreInfo.itemSprites[0];
        }
    }
}
