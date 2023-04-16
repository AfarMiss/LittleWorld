using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Food : WorldObject
    {
        public RawFoodInfo foodInfo;
        public Food(int itemCode, Vector2Int gridPos) : base(itemCode, gridPos)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var foodInfo))
            {
                this.foodInfo = foodInfo as RawFoodInfo;
                this.itemCode = itemCode;
                ItemName = foodInfo.itemName;
            }
        }

        public override Sprite GetCurrentSprite()
        {
            return foodInfo.ItemSprites[0];
        }
    }
}
