using BehaviourTreeUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public abstract class Work
    {
        public static int WorkIDSeed = 0;

        protected BehaviourTree workBehaviourTree;

    }
}
