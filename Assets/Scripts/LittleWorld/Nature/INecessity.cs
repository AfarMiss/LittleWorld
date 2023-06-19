using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public interface IEatable
    {
        bool eatable { get; }
        float maxNutrition { get; }
        float leftNutrition { get; }
        string itemName { get; }
        float eatDuration { get; }
        bool canEatPartly { get; }
        void OnBeEaten(HealthTracer healthTracer);
        void OnBeEatenCompletely();
    }

    public interface IDrinkable
    {
        /// <summary>
        /// 含水量，-1代表无穷
        /// </summary>
        float maxMositure { get; }
        float leftMositure { get; }
        string itemName { get; }
        float drinkDuration { get; }
        bool canDrinkPartly { get; }

        void BeDrunkCompletely();
        void BeDrunk(HealthTracer health);

    }

    public interface ISleepable
    {
        bool isSleepable { get; }
        string itemName { get; }
    }
}
