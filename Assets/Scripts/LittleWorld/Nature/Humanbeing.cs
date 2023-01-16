using LittleWorld;
using LittleWorld.Work;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Object
{
    public class Humanbeing : Animal
    {
        private PawnWorkTracer pawnWorkTracer;
        private PawnHealthTracer PawnHealthTracer;
        private PawnPathTracer PawnPathTracer;

        public Queue<HumanAction> actionQueue;

        public Humanbeing(Vector3Int gridPos) : base(gridPos)
        {
            ItemName = "人类";
            moveSpeed = 9;

            this.gridPos = gridPos;
            actionQueue = new Queue<HumanAction>();
            pawnWorkTracer = new PawnWorkTracer(this);
        }

        public void AddWork(WorkTypeEnum workType, Vector3Int targetPos)
        {
            Action whenReached = null;
            var totalWorkAmount = 24;
            var showPercent = true;
            var workerPos = WorkUtility.GetRandomWorkAroundPoint(targetPos);
            switch (workType)
            {
                case WorkTypeEnum.dug:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.water:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.gotoLoc:
                    workerPos = targetPos;
                    showPercent = false;
                    totalWorkAmount = 0;
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

            var curWork =
    new SingleWork($"{this.instanceID}_{workType}_{PawnWorkTracer.workID++}",
    this,
    WorkStateEnum.None,
    workType,
    whenReached,
    targetPos,
    0,
    totalWorkAmount,
    workerPos,
    showPercent);

            if (!Current.IsAdditionalMode)
            {
                pawnWorkTracer.ClearAndAddWork(curWork);
            }
            else
            {
                pawnWorkTracer.AddWork(curWork);
            }
        }

        public override void Tick()
        {
            base.Tick();
            pawnWorkTracer.Tick();
        }
    }
}