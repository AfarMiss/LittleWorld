using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class RawFood : WorldObject
    {
        public RawFoodInfo foodInfo;

        public RawFood(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var foodInfo))
            {
                this.foodInfo = foodInfo as RawFoodInfo;
                ItemName = foodInfo.itemName;
            }
        }

        public override Sprite GetSprite()
        {
            return foodInfo.itemSprites[0];
        }
    }
}
