using AI;
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
            AddWork(new NonAggressiveBT(this.animal));
        }
    }
}
