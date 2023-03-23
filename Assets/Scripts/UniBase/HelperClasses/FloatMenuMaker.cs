﻿using LittleWorld.Item;
using LittleWorld.MapUtility;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEngine;

namespace LittleWorld.UI
{
    public static class FloatMenuMaker
    {
        public static FloatOption[] MakeFloatMenuAt(Humanbeing human, Vector3 mousePos)
        {
            var contentList = new List<FloatOption>();
            var cell = mousePos.GetWorldPosition();

            foreach (var worldObject in WorldUtility.GetObjectsAtCell(cell))
            {
                if (worldObject is Plant plant)
                {
                    var plantOpts = AddPlantFloatMenu(human, plant);
                    AddOption(contentList, plantOpts);
                }

                if (worldObject is PlantMapSection section)
                {
                    var plantOpts = AddPlantSectionFloatMenu(human, mousePos.GetWorldPosition().ToCell(), section);
                    AddOption(contentList, plantOpts);
                }
                if (worldObject is Ore ore)
                {
                    var plantOpts = AddOreFloatMenu(human, ore);
                    AddOption(contentList, plantOpts);
                }

                if (worldObject is Building building)
                {
                    var plantOpts = AddBuildingFloatMenu(human, building);
                    AddOption(contentList, plantOpts);
                }

                if (worldObject is Weapon weapon)
                {
                    var plantOpts = AddWeaponFloatMenu(human, weapon);
                    AddOption(contentList, plantOpts);
                }
            }

            var haulOpts = AddHaulFloatMenu(human, cell);
            AddOption(contentList, haulOpts);

            UIManager.Instance.ShowFloatOptions(contentList);

            return contentList.ToArray();
        }

        private static void AddOption(List<FloatOption> contentList, List<FloatOption> haulOpts)
        {
            if (haulOpts != null)
            {
                contentList.AddRange(haulOpts);
            }
        }

        private static List<FloatOption> AddBuildingFloatMenu(Humanbeing human, Building building)
        {
            if (building.buildingStatus != BuildingStatus.BluePrint)
            {
                return null;
            }
            List<FloatOption> contentList = new List<FloatOption>
            {
            new FloatOption($"建造{building.ItemName}", () =>
            {
                human.AddBuildingWork(building);
            })
            };
            return contentList;

        }

        private static List<FloatOption> AddWeaponFloatMenu(Humanbeing human, Weapon weapon)
        {
            List<FloatOption> contentList = new List<FloatOption>
            {
            new FloatOption($"装备{weapon.ItemName}", () =>
            {
                human.AddEquipWork(weapon);
            })
            };
            return contentList;

        }

        private static List<FloatOption> AddHaulFloatMenu(Humanbeing human, Vector3 pos)
        {
            var results = new List<WorldObject>();
            foreach (var item in WorldUtility.GetObjectsAtCell(pos))
            {
                if (item is WorldObject wo && wo.canPile)
                {
                    results.Add(item as WorldObject);
                }
            }
            if (results.Count <= 0)
            {
                return null;
            }
            List<FloatOption> contentList = new List<FloatOption>
            {
            new FloatOption($"搬运{(results[0] ).ItemName}x{results.Count}", () =>
            {
                human.AddCarryWork(results.ToArray() );
            })
            };
            return contentList;
        }

        public static List<FloatOption> AddPlantFloatMenu(Humanbeing worker, Plant plant)
        {
            List<FloatOption> contentList = new List<FloatOption>()
            {
                 new FloatOption($"割除{ObjectConfig.GetPlantName(plant.itemCode) }", () =>
            {
                    worker.AddCutWork(plant);
            })

            };

            return contentList;
        }

        public static List<FloatOption> AddOreFloatMenu(Humanbeing worker, Ore ore)
        {
            List<FloatOption> contentList = new List<FloatOption>()
            {
                 new FloatOption($"开采{ObjectConfig.GetOreName(ore.itemCode) }", () =>
            {
                    worker.AddOreWork(ore);
            })

            };

            return contentList;
        }

        public static List<FloatOption> AddPlantSectionFloatMenu(Humanbeing worker, Vector3Int targetPos, PlantMapSection section)
        {
            List<FloatOption> contentList = new List<FloatOption>
            {
                new FloatOption($"种植{ObjectConfig.GetPlantName(section.SeedCode) }", () =>
            {
                worker.AddSowWork(section,section.SeedCode);
            })
            };
            if (section.CanHarvest)
            {
                contentList.Add(new FloatOption($"收获{section.sectionName}", () =>
                {
                    worker.AddHarvestWork(section, ObjectConfig.GetPlantCode(section.SeedCode));
                }));
            }
            return contentList;
        }
    }
}
