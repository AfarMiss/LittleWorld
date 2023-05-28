using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.MoveLeaf;
using static UnityEngine.Rendering.DebugUI;

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

    public class EatWork : IToil
    {
        public Animal animal;
        public IEatable eatable;

        public EatWork(Animal animal, IEatable eatable)
        {
            this.animal = animal;
            this.eatable = eatable;
        }

        public bool isDone => !animal.isEating;

        public void ToilStart()
        {
            animal.Eat(eatable);
        }

        public bool ToilTick()
        {
            return !animal.isEating;
        }
    }
}
