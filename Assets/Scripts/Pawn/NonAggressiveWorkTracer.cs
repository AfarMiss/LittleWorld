using LittleWorld.Item;
using LittleWorld.Jobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class NonAggressiveWorkTracer : WorkTracer
    {
        public NonAggressiveWorkTracer(Animal animal) : base(animal)
        {
        }

        protected override void OnNoWork()
        {
            base.OnNoWork();
            AddWork(new WanderWork(animal));
        }
    }
}
