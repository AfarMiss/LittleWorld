﻿using AI;
using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Jobs
{
    public class GoToLocWork : Work
    {
        public GoToLocWork(Humanbeing humanbeing, Vector2Int destination)
        {
            tree = new BehaviourTree();
            WalkLeaf dynamicWalk = new WalkLeaf("Go To Loc", destination, humanbeing);
            tree.AddChild(dynamicWalk);
        }
    }
}
