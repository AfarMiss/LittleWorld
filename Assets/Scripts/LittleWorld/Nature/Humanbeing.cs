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
using AI;

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
        public List<WorldObject> Inventory = new List<WorldObject>();
        public GearTracer gearTracer;

        public bool CarrySingle(WorldObject wo, Vector2Int destination)
        {
            Current.CurMap.TryGetGrid(destination, out var result);
            return result.PickUp(wo, this);
        }

        public bool CarrySingle(int itemCode, Vector2Int destination, out WorldObject wo)
        {
            Current.CurMap.TryGetGrid(destination, out var result);
            return result.PickUp(itemCode, this, out wo);
        }

        public void Carry(WorldObject[] wo, Vector2Int destination)
        {
            foreach (var item in wo)
            {
                CarrySingle(item, destination);
            }
        }


        public WorldObject[] Carry(int itemCode, int amount, Vector2Int destination)
        {
            var result = new List<WorldObject>();
            for (int i = 0; i < amount; i++)
            {
                CarrySingle(itemCode, destination, out var wo);
                if (wo != null)
                {
                    result.Add(wo);
                }
            }
            return result.ToArray();
        }

        private void Dropdown(WorldObject wo)
        {
            wo.OnBeDropDown();
        }

        public void Dropdown(WorldObject[] wo, Vector2Int destination)
        {
            foreach (var item in wo)
            {
                Dropdown(item);
            }
        }


        public MotionStatus motion = MotionStatus.Idle;

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
            gearTracer = new GearTracer(this);
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

        public void AddEquipWork(Weapon weapon)
        {
            workTracer.AddWork(new EquipWork(weapon, this));
        }

        public void AddEquip(Weapon weapon, Vector2Int destination)
        {
            CarrySingle(weapon, destination);
            gearTracer.AddEquip(weapon);
        }

        public override void Tick()
        {
            base.Tick();
            workTracer?.Tick();
            //Debug.Log("pos:" + GridPos);
        }

        internal void AddBuildingWork(Building building)
        {
            workTracer.AddWork(new BuildingHaulingWork(building, this));
            workTracer.AddWork(new BuildingWork(building, this));
        }
    }
}