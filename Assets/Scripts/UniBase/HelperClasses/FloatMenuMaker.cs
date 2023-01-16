using LittleWorld.Object;
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

            var worldObjects = WorldUtility.GetWorldObjectsAt(mousePos.GetWorldPosition());

            foreach (var worldObject in worldObjects)
            {
                if (worldObject is Plant curPlant)
                {
                    var plantOpts = AddPlantFloatMenu(human, mousePos.GetWorldPosition().ToCell(), curPlant);
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
                    worker.AddWork(WorkTypeEnum.chop, targetPos);
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
    }
}
