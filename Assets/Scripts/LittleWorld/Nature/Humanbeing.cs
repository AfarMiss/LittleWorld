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
using UnityEngine.UI;

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

        public void CarrySingle(WorldObject wo, Vector2Int destination)
        {
            Current.CurMap.TryGetGrid(destination, out var result);
            result.PickUp(wo, this);
        }

        public void Carry(WorldObject[] wo, Vector2Int destination)
        {
            foreach (var item in wo)
            {
                CarrySingle(item, destination);
            }
        }

        private void Dropdown(WorldObject wo, Vector2Int destination)
        {
            wo.OnBeDropDown();
        }

        public void Dropdown(WorldObject[] wo, Vector2Int destination)
        {
            foreach (var item in wo)
            {
                Dropdown(item, destination);
            }
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
            animalInfo = ObjectConfig.ObjectInfoDic[itemCode] as AnimalInfo;
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

        public void AddCarryWork(WorldObject[] wo)
        {
            workTracer.AddWork(new HaulingWork(wo, this));
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

        internal void AddBuildingWork(Building building)
        {
            workTracer.AddWork(new BuildingWork(building, this));
        }
    }
}