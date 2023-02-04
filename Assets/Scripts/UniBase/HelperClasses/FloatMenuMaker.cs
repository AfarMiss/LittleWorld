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
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InteractionMenu/InteractionMenu"));
            go.name = go.name.Substring(0, go.name.LastIndexOf("(Clone)"));
            var menu = go.GetComponent<InteractionMenu>();
            go.transform.SetParent(GameObject.FindGameObjectWithTag("UICanvas")?.transform);
            go.transform.position = Current.MousePos;

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

            UIManager.Instance.ReactMenu = contentList.Count != 0;
            menu.BindData(contentList);

            return contentList.ToArray();
        }

        public static List<FloatOption> AddPlantFloatMenu(Humanbeing worker, Vector3Int targetPos, Plant plant)
        {
            List<FloatOption> contentList = new List<FloatOption>();

            return contentList;
        }

        public static List<FloatOption> AddPlantSectionFloatMenu(Humanbeing worker, Vector3Int targetPos, PlantMapSection section)
        {
            List<FloatOption> contentList = new List<FloatOption>();
            contentList.Add(new FloatOption()
            {
                content = $"种植{section.sectionName}",
                OnClickOption = () =>
                {
                    worker.AddWork(WorkTypeEnum.sow, targetPos);
                }
            });
            if (section.CanHarvest)
            {
                contentList.Add(new FloatOption()
                {
                    content = $"收获{section.sectionName}",
                    OnClickOption = () =>
                    {
                        worker.AddWork(WorkTypeEnum.harvest, targetPos);
                    }
                });
            }
            return contentList;
        }
    }
}
