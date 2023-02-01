using LittleWorld.Extension;
using LittleWorld;
using LittleWorld.Jobs;
using LittleWorld.MapUtility;
using LittleWorld.WorkUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Debug.Log("Humanbeing");
            ItemName = "人类";
            moveSpeed = 9;
            itemCode = 10026;

            this.gridPos = gridPos;
            actionQueue = new Queue<HumanAction>();
            workTracer = new PawnWorkTracer(this);

        }

        public void AddWork(WorkTypeEnum workType, Vector3Int targetPos)
        {
            switch (workType)
            {
                case WorkTypeEnum.dug:
                    break;
                case WorkTypeEnum.water:
                    break;
                case WorkTypeEnum.gotoLoc:
                    workTracer.AddWork(new GoToLocWork(this, targetPos.To2()));
                    break;
                case WorkTypeEnum.cut:
                    break;
                case WorkTypeEnum.harvest:
                    break;
                case WorkTypeEnum.sow:
                    var grids = WorldUtility.GetWorldObjectsAt(targetPos).OfType<MapSection>();
                    if (grids.Safe().Any())
                    {
                        workTracer.AddWork(new SowWork(ObjectCode.wheatPlant.ToInt(), grids.ToList().First().grids, this));
                    }
                    break;
                default:
                    break;
            }
        }

        public override void Tick()
        {
            base.Tick();
            workTracer.Tick();
        }
    }
}