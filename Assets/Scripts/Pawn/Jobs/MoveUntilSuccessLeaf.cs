﻿using LittleWorld;
using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.MoveLeaf;

namespace AI
{
    public class MoveUntilSuccessLeaf : Node
    {
        public Vector2Int destination;
        public Animal animal;
        public bool surround = true;
        public delegate Status Tick(Vector2Int destination, Animal animal, MoveType moveType);
        public Tick ProcessMethod;
        private MoveType moveType;
        public delegate Vector2Int CalculatePath();
        private CalculatePath calculateFunc;

        public MoveUntilSuccessLeaf(string name, Animal animal, CalculatePath calculateFunc, MoveType moveType = MoveType.walk)
        {
            Init(name, animal, calculateFunc, moveType);
        }

        private void Init(string name, Animal animal, CalculatePath calculateFunc, MoveType moveType)
        {
            var curDestination = calculateFunc();
            while (!Current.CurMap.GetGrid(Current.CurMap.ValidateGridPos(calculateFunc())).isLand)
            {
                Debug.LogWarning($"重新计算目的地 for MoveUntilSuccessLeaf,旧:{curDestination}");
                curDestination = calculateFunc();
                Debug.LogWarning($"重新计算目的地 for MoveUntilSuccessLeaf,新:{curDestination}");
            }
            this.destination = curDestination;
            this.animal = animal;
            this.name = name;
            this.ProcessMethod = GoToLoc;
            this.moveType = moveType;
            this.calculateFunc = calculateFunc;
        }

        protected override void Reset()
        {
            var curDestination = calculateFunc();
            while (!Current.CurMap.GetGrid(curDestination).isLand)
            {
                Debug.LogWarning($"重新计算目的地 for MoveUntilSuccessLeaf,旧:{curDestination}");
                curDestination = calculateFunc();
                Debug.LogWarning($"重新计算目的地 for MoveUntilSuccessLeaf,新:{curDestination}");
            }
            this.destination = curDestination;
        }

        public override Status Process()
        {
            //Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod(destination, animal, moveType);
            return Status.Failure;
        }

    }
}
