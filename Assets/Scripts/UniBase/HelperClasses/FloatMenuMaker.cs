using LittleWorld.Item;
using LittleWorld.MapUtility;
using System.Collections.Generic;
using UniBase;
using UnityEngine;

namespace LittleWorld.UI
{
    public static class FloatMenuMaker
    {
        public static FloatOption[] MakeFloatMenuAt(Humanbeing human, Vector3 mousePos)
        {
            var contentList = new List<FloatOption>();

            var objects = WorldUtility.GetWorldObjectsAt(mousePos.GetWorldPosition());

            foreach (var worldObject in objects)
            {
                if (worldObject is Plant curPlant)
                {
                    var plantOpts = AddPlantFloatMenu(human, mousePos.GetWorldPosition().ToCell(), curPlant);
                    contentList.AddRange(plantOpts);
                }

                if (worldObject is PlantMapSection curSection)
                {
                    var plantOpts = AddPlantSectionFloatMenu(human, mousePos.GetWorldPosition().ToCell(), curSection);
                    contentList.AddRange(plantOpts);
                }
            }

            UIManager.Instance.ShowFloatOptions(contentList);

            return contentList.ToArray();
        }

        public static List<FloatOption> AddPlantFloatMenu(Humanbeing worker, Vector3Int targetPos, Plant plant)
        {
            List<FloatOption> contentList = new List<FloatOption>();

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
