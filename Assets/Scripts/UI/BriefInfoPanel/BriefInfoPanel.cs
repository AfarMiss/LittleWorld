using LittleWorld.Interface;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LittleWorld.UI
{
    public class BriefInfoPanel : BaseUI
    {
        public override string Path => UIPath.Panel_BriefInfoPanel;
        [SerializeField] private BriefInfoItem briefItem1;
        [SerializeField] private Text InfoTitle;
        [SerializeField] private Transform briefItemParent;
        [SerializeField] private GameObject itemCommandGameObject;
        [SerializeField] private Transform commandParent;

        private List<BriefInfoItem> briefInfoItems;
        public void BindBriefInfo(LittleWorld.Item.Object[] objects)
        {
            if (objects.Length > 1)
            {
                InfoTitle.text = "多种x" + objects.Length;
            }
            else if (objects.Length == 1)
            {
                var wo = objects[0];
                InfoTitle.text = wo.ItemName;

                for (int i = 0; i < commandParent.childCount; i++)
                {
                    Destroy(commandParent.GetChild(0).gameObject);
                }

                BindCommands(wo);
            }
        }

        private void BindCommands(Item.Object item)
        {
            if (item is PlantMapSection)
            {
                AddCommand("更改种植作物", () =>
                {
                    List<FloatOption> list = new List<FloatOption>();
                    foreach (var item in ObjectConfig.plantInfoDic)
                    {
                        list.Add(new FloatOption(item.Value.itemName, null));
                    }
                    UIManager.Instance.ShowFloatOptions(list);
                });
            }
        }

        private void AddCommand(string commandName, UnityAction action)
        {
            var go = Instantiate(itemCommandGameObject, commandParent);
            go.GetComponent<BriefCommandIcon>().BindData(commandName, action);
        }
    }
}
