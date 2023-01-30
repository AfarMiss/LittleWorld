using LittleWorld;
using LittleWorld.WorkUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Humanbeing : Animal
    {
        public enum MotionStatus
        {
            Idle,
            Running,
        }

        private PawnWorkTracer workTracer;
        private PawnHealthTracer healthTracer;
        private PathNavigation pathTracer;

        public MotionStatus motion = MotionStatus.Idle;

        public void SetNavi(PathNavigation PawnPathTracer)
        {
            this.pathTracer = PawnPathTracer;
        }

        public int GetWorkSpeed(WorkTypeEnum type)
        {
            switch (type)
            {
                case WorkTypeEnum.dug:
                    return 2;
                case WorkTypeEnum.water:
                    return 2;
                case WorkTypeEnum.gotoLoc:
                    return 2;
                case WorkTypeEnum.cut:
                    return 2;
                case WorkTypeEnum.harvest:
                    return 2;
                case WorkTypeEnum.sow:
                    return 2;
                default:
                    return 2;
            }
        }

        public void GoToLoc(Vector2Int target)
        {
            pathTracer.GoToLoc(target);
        }

        public Queue<HumanAction> actionQueue;
        public MotionStatus motionStatus;

        public Humanbeing(Vector2Int gridPos) : base(gridPos)
        {
            ItemName = "人类";
            moveSpeed = 9;

            this.gridPos = gridPos;
            actionQueue = new Queue<HumanAction>();
            workTracer = new PawnWorkTracer(this);
        }

        public void AddWork(WorkTypeEnum workType, Vector3Int targetPos)
        {
            Action whenReached = null;
            var totalWorkAmount = 24;
            var showPercent = true;
            var workerPos = WorkUtility.WorkUtility.GetRandomWorkAroundPoint(targetPos);
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
                case WorkTypeEnum.cut:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.harvest:
                    totalWorkAmount = 240;
                    break;
                case WorkTypeEnum.sow:
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
                workTracer.ClearAndAddWork(curWork);
            }
            else
            {
                workTracer.AddWork(curWork);
            }
        }

        public override void Tick()
        {
            base.Tick();
            workTracer.Tick();
        }
    }
}