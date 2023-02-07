using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Animal : WorldObject
    {
        protected AnimalInfo animalInfo;
        public float moveSpeed => animalInfo.moveSpeed;

        public Animal(int itemCode, Vector2Int gridPos) : base(itemCode, gridPos)
        {
        }

        public override Sprite GetSprite()
        {
            return animalInfo.itemSprites[0];
        }
    }
}

