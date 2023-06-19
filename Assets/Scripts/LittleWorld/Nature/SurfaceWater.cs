using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class SurfaceWater : Thing, IDrinkable
    {
        public SurfaceWater(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
        }

        public float maxMositure => -1;

        public float drinkDuration => 2f;

        public float leftMositure => -1;

        public bool canDrinkPartly => true;

        string IDrinkable.itemName => this.ItemName;

        public void BeDrunk(HealthTracer healthTracer)
        {
            healthTracer.curThirsty = healthTracer.maxThirsty;
            //var needThirsty = healthTracer.maxHunger - healthTracer.curHunger;
            //if (leftMositure == -1)
            //{

            //}
            //else
            //{
            //    if (needThirsty > leftMositure)
            //    {
            //        healthTracer.curThirsty += leftMositure;
            //        BeDrunkCompletely();
            //    }
            //    else
            //    {
            //        healthTracer.curThirsty = healthTracer.maxThirsty;
            //        if (canDrinkPartly)
            //        {
            //            leftMositure -= needThirsty;
            //        }
            //        else
            //        {
            //            EatenTotally();
            //        }
            //    }
            //}

        }

        public void BeDrunkCompletely()
        {
        }

        public override Sprite GetCurrentSprite()
        {
            return null;
        }
    }
}
