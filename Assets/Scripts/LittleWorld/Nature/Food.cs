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
            if (ObjectConfig.rawFoodInfo.TryGetValue(itemCode, out foodInfo))
            {
                foodInfo = ObjectConfig.rawFoodInfo[itemCode];
                this.itemCode = itemCode;
                ItemName = foodInfo.itemName;
            }
        }

        public override Sprite GetSprite()
        {
            return foodInfo.itemSprites[0];
        }
    }
}
