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
using System.Net.Cache;
using static LittleWorld.HealthTracer;

namespace LittleWorld.Item
{
    public class Humanbeing : Animal
    {
        public List<WorldObject> Inventory = new List<WorldObject>();
        public GearTracer gearTracer;

        public bool CarrySingle(WorldObject wo, Vector2Int destination)
        {
            Current.CurMap.GetGrid(destination, out var result);
            return result.PickUp(wo, this);
        }

        public bool CarrySingle(int itemCode, Vector2Int destination, out WorldObject wo)
        {
            Current.CurMap.GetGrid(destination, out var result);
            return result.PickUp(itemCode, this, out wo);
        }

        public void Carry(WorldObject[] wo, Vector2Int destination)
        {
            foreach (var item in wo)
            {
                CarrySingle(item, destination);
            }
        }

        public void Eat(IEatable eatable)
        {
            healthTracer.Eat(eatable);
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

        public void StopFire()
        {
            gearTracer.curWeapon.StopFire();
        }

        public int GetWorkSpeed(WorkTypeEnum type)
        {
            switch (type)
            {
                case WorkTypeEnum.dug:
                    return 6;
                case WorkTypeEnum.water:
                    return 6;
                case WorkTypeEnum.gotoLoc:
                    return 6;
                case WorkTypeEnum.cut:
                    return 6;
                case WorkTypeEnum.harvest:
                    return 6;
                case WorkTypeEnum.sow:
                    return 6;
                case WorkTypeEnum.carry:
                    return 6;
                default:
                    return 6;
            }
        }

        public MotionStatus motionStatus;

        public Humanbeing(int itemCode, Age age, Vector2Int gridPos) : base(itemCode, age, gridPos)
        {
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

        public void AddFireWork(Animal animal)
        {
            workTracer.AddWork(new HuntWork(this, animal));
        }

        public void FireAt(Animal animal)
        {
            gearTracer.TryFireAt(animal);
        }

        public void AddEquip(Weapon weapon, Vector2Int destination)
        {
            CarrySingle(weapon, destination);
            gearTracer.AddEquip(weapon);
        }

        public void AddBuildingWork(Building building)
        {
            workTracer.AddWork(new BuildingHaulingWork(building, this));
            workTracer.AddWork(new BuildingWork(building, this));
        }

        public void AddDeconstructWork(Building building)
        {
            workTracer.AddWork(new BuildingHaulingWork(building, this));
            workTracer.AddWork(new BuildingWork(building, this));
        }


    }
}