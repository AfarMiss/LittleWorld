using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Food : WorldObject
    {
        public RawFoodInfo foodInfo;
        public float nutrition;
        public Food(Vector2Int gridPos) : base(gridPos)
        {
        }

        public override Sprite GetSprite()
        {
            return foodInfo.itemSprites[0];
        }
    }
}
