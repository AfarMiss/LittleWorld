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
using UnityEditor;
using UnityEngine.UI;
using AI;
using System.Net.Cache;
using static LittleWorld.HealthTracer;

namespace LittleWorld.Item
{
    public class Humanbeing : Animal
    {
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

        public void AddEquipWork(Weapon weapon)
        {
            workTracer.AddWork(new EquipWork(weapon, this));
        }

        /// <summary>
        /// 狩猎工作，之后AI可以参考
        /// </summary>
        /// <param name="animal"></param>
        public void AddHuntWork(Animal animal)
        {
            workTracer.AddWork(new HuntWork(this, animal));
        }

        public void AddEquip(Weapon weapon, Vector2Int destination)
        {
            CarrySingle(weapon, destination);
            gearTracer.AddEquip(weapon);
        }

        public void AddBuildingWork(Building building)
        {
            //workTracer.AddToil(new BuildingToil(building));
        }

        public void AddDeconstructWork(Building building)
        {
            workTracer.AddWork(new BuildingWork(building, this));
        }


    }
}