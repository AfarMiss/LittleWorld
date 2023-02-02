﻿using LittleWorld.Extension;
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
            itemCode = ObjectCode.humanbeing.ToInt();

            this.gridPos = gridPos;
            actionQueue = new Queue<HumanAction>();
            workTracer = new PawnWorkTracer(this);
            animalInfo = ObjectConfig.animalInfo[itemCode];

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
                        workTracer.AddWork(new SowWork(ObjectCode.cornSeed.ToInt(), grids.ToList().First().grids, this));
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