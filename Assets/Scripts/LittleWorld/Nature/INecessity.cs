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
        void BeEaten(HealthTracer healthTracer);
        void OnBeEatenDispose();
    }

    public interface IDrinkable
    {
        /// <summary>
        /// 含水量
        /// </summary>
        float mositure { get; }
        string itemName { get; }
        float eatDuration { get; }
    }

    public interface ISleepable
    {
        bool isSleepable { get; }
        string itemName { get; }
    }
}
