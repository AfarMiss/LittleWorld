using LittleWorld.Item;
using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniBase;
using UnityEngine;

namespace LittleWorld.Window
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

                if (worldObject is MapSection curSection)
                {
                    var plantOpts = AddSectionFloatMenu(human, mousePos.GetWorldPosition().ToCell(), curSection);
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
            contentList.Add(new FloatOption()
            {
                content = $"伐除{plant.GetType().Name}",
                OnClickOption = () =>
                {
                    worker.AddWork(WorkTypeEnum.cut, targetPos);
                }
            });
            contentList.Add(new FloatOption()
            {
                content = $"摘取{plant.GetType().Name}果实",
                OnClickOption = () =>
                {
                    worker.AddWork(WorkTypeEnum.harvest, targetPos);
                }
            });

            return contentList;
        }

        public static List<FloatOption> AddSectionFloatMenu(Humanbeing worker, Vector3Int targetPos, MapSection section)
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

            return contentList;
        }
    }
}
