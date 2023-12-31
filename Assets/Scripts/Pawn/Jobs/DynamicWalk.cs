﻿using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.MoveLeaf;

namespace AI
{
    public class DynamicWalk : Node
    {
        public Vector2Int destination;
        public Humanbeing human;
        public bool surround = true;
        public delegate Status Tick(Vector2Int destination, Humanbeing human, MoveType moveType);
        public delegate Vector2Int GetPos();
        public Tick ProcessMethod;
        public MoveType moveType;
        public GetPos getPos;

        public DynamicWalk(string name, Humanbeing human, Tick tick, GetPos getPos, NodeGraph graph = null, MoveType moveType = MoveType.walk) : base(name, graph)
        {
            this.human = human;
            this.name = name;
            this.ProcessMethod = tick;
            this.getPos = getPos;
            this.moveType = moveType;
        }

        public override Status Process()
        {
            if (getPos != null)
            {
                destination = getPos();
            }
            if (destination == VectorExtension.undefinedV2Int)
            {
                return Status.Failure;
            }
            //Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
            {
                return ProcessMethod(destination, human, moveType);
            }
            return Status.Failure;
        }
    }
}
