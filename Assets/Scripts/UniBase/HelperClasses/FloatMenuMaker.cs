using LittleWorld.Item;
using LittleWorld.MapUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using Unity.VisualScripting;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

namespace LittleWorld.UI
{
    public static class FloatMenuMaker
    {
        public static FloatOption[] MakeFloatMenuAt(Humanbeing human, Vector3 mousePos)
        {
            var contentList = new List<FloatOption>();
            var cell = mousePos.GetWorldPosition();
            var objects = WorldUtility.GetWorldObjectsAt(cell);
            bool hasAddedHaul = false;

            foreach (var worldObject in objects)
            {
                if (worldObject is Plant curPlant)
                {
                    var plantOpts = AddPlantFloatMenu(human, curPlant);
                    contentList.AddRange(plantOpts);
                }

                if (worldObject is PlantMapSection curSection)
                {
                    var plantOpts = AddPlantSectionFloatMenu(human, mousePos.GetWorldPosition().ToCell(), curSection);
                    contentList.AddRange(plantOpts);
                }
                if (worldObject is WorldObject && (worldObject as WorldObject).canPile && !hasAddedHaul)
                {
                    var plantOpts = AddHaulFloatMenu(human, objects);
                    contentList.AddRange(plantOpts);
                    hasAddedHaul = true;
                }
                if (worldObject is Ore)
                {
                    var plantOpts = AddOreFloatMenu(human, worldObject as Ore);
                    contentList.AddRange(plantOpts);
                }

                if (worldObject is Building building && building.buildingStatus == BuildingStatus.BluePrint)
                {
                    var plantOpts = AddBuildingFloatMenu(human, building);
                    contentList.AddRange(plantOpts);
                }
            }

            UIManager.Instance.ShowFloatOptions(contentList);

            return contentList.ToArray();
        }

        private static List<FloatOption> AddBuildingFloatMenu(Humanbeing human, Building building)
        {
            List<FloatOption> contentList = new List<FloatOption>
            {
            new FloatOption($"建造{building.ItemName}", () =>
            {
                human.AddBuildingWork(building);
            })
            };
            return contentList;
        }

        private static List<FloatOption> AddHaulFloatMenu(Humanbeing human, Item.Object[] objects)
        {
            var haulTargets = objects.ToList().FindAll(x => x is WorldObject wo && wo.canPile);
            var results = new List<WorldObject>();
            foreach (var item in haulTargets)
            {
                results.Add(item as WorldObject);
            }
            List<FloatOption> contentList = new List<FloatOption>
            {
            new FloatOption($"搬运{(haulTargets[0] as WorldObject).ItemName}x{haulTargets.Count}", () =>
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
