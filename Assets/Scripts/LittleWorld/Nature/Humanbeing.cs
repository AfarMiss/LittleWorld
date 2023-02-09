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
using UnityEditor;

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
        public List<WorldObject> Inventory = new List<WorldObject>();
        public WorldObject CurrentTake;

        public void Carry(WorldObject wo)
        {
            wo.OnBeCarried(this);
            Inventory.Add(wo);
            CurrentTake = wo;
        }

        public void Dropdown(WorldObject wo)
        {
            wo.OnBeDropDown();
            if (CurrentTake == wo)
            {
                CurrentTake = null;
            }
            Inventory.Remove(wo);
        }


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
                case WorkTypeEnum.carry:
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

        public Humanbeing(int itemCode, Vector2Int gridPos) : base(itemCode, gridPos)
        {
            actionQueue = new Queue<HumanAction>();
            workTracer = new PawnWorkTracer(this);
            animalInfo = ObjectConfig.animalInfo[itemCode];
            ItemName = animalInfo.itemName;
        }

        public void AddHarvestWork(PlantMapSection section, int plantCode)
        {
            workTracer.AddWork(new HarvestWork(plantCode, section.grids, this));
        }

        public void AddSowWork(PlantMapSection section, int seedCode)
        {
            workTracer.AddWork(new SowWork(seedCode, section.grids, this));
        }

        public void AddCutWork(Plant plant)
        {
            workTracer.AddWork(new CutSingleWork(plant, this));
        }

        public void AddOreWork(Ore ore)
        {
            workTracer.AddWork(new MiningSingleWork(ore, this));
        }

        public void AddCarryWork(WorldObject wo)
        {
            workTracer.AddWork(new CarryWork(wo, this));
        }

        public void AddMoveWork(Vector3Int targetPos)
        {
            workTracer.AddWork(new GoToLocWork(this, targetPos.To2()));

        }

        public override void Tick()
        {
            base.Tick();
            workTracer?.Tick();
            //Debug.Log("pos:" + GridPos);
        }
    }
}