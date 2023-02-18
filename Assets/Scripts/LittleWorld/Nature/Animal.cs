using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Animal : WorldObject
    {
        protected PathNavigation pathTracer;
        protected AnimalInfo animalInfo;
        public float moveSpeed => animalInfo.moveSpeed;

        public Animal(int itemCode, Vector2Int gridPos) : base(itemCode, gridPos)
        {
            animalInfo = ObjectConfig.ObjectInfoDic[itemCode] as AnimalInfo;
        }
        public void SetNavi(PathNavigation PawnPathTracer)
        {
            this.pathTracer = PawnPathTracer;
        }
        public override Sprite GetSprite()
        {
            return animalInfo.itemSprites[0];
        }
    }
}

