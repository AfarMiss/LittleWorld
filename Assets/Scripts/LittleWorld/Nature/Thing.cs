using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Thing : WorldObject
    {
        public ThingInfo ThingInfo;
        public Thing(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            if (ObjectConfig.thingInfo.TryGetValue(itemCode, out ThingInfo))
            {
                ThingInfo = ObjectConfig.thingInfo[itemCode];
                ItemName = ThingInfo.itemName;
            }
        }

        public override Sprite GetSprite()
        {
            return ThingInfo.itemSprites[0];
        }
    }
}
