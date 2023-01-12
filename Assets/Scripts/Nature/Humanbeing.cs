using LittleWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorldObject
{
    public class Humanbeing : Animal
    {
        private PawnWorkTracer pawnWorkTracer;
        public Humanbeing(Vector3Int gridPos) : base(gridPos)
        {
            this.gridPos = gridPos;
            ItemName = "人类";
            actionQueue = new Queue<HumanAction>();
            curInteractionItemID = -1;

            pawnWorkTracer = new PawnWorkTracer(this);
        }
        public Queue<HumanAction> actionQueue;
        public Coroutine curPickCoroutine;
        public int curInteractionItemID;

        public void AddWork(WorkTypeEnum workType, Vector3Int targetPos)
        {
            Action whenReached = null;
            var totalWorkAmount = 24;
            switch (workType)
            {
                case WorkTypeEnum.dug:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.water:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.gotoLoc:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.chop:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.harvest:
                    totalWorkAmount = 240;
                    break;
                default:
                    break;
            }
            pawnWorkTracer.AddWork(
                new SingleWork($"{this.instanceID}_{workType}_{PawnWorkTracer.workID++}",
                this,
                WorkStateEnum.None,
                workType,
                whenReached,
                targetPos,
                0,
                totalWorkAmount));
        }

        public override void Tick()
        {
            base.Tick();
            pawnWorkTracer.Tick();
        }
    }
}