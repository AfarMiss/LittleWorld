using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Animal : WorldObject
    {
        protected AnimalInfo animalInfo;
        public float MoveSpeed => animalInfo.moveSpeed;

        public Animal(Vector2Int gridPos) : base(gridPos)
        {
        }

        public override Sprite GetSprite()
        {
            return animalInfo.itemSprites[0];
        }
    }
}

