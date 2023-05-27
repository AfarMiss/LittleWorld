using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.MoveLeaf;

namespace LittleWorld.Jobs
{
    public class SleepWork : IToil
    {
        public Animal animal;
        public Vector2Int target;

        public SleepWork(Animal animal, Vector2Int target)
        {
            this.animal = animal;
            this.target = target;
        }

        public bool isDone => !animal.isSleeping;

        public void ToilStart()
        {
            animal.Sleep();
        }

        public bool ToilTick()
        {
            return !animal.isSleeping;
        }
    }
}
