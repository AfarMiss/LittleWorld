using LittleWorld.Interface;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using SRF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static LittleWorld.UI.DynamicCommandIcon;

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

        public void BindBriefInfo(Item.Object[] objects)
        {
            if (objects.Length > 1)
            {
                InfoTitle.text = "多种x" + objects.Length;
            }
            else if (objects.Length == 1)
            {
                var wo = objects[0];
                InfoTitle.text = wo.ItemName;
                commandParent.DestroyChildren();
                BindCommands(wo);
            }
        }

        private void BindCommands(Item.Object item)
        {
            if (item is PlantMapSection map)
            {
                var command1 = AddCommand("更改种植作物", ObjectConfig.GetPlantSprite(map.SeedCode));
                command1.BindCommand(() =>
                {
                    List<FloatOption> list = new List<FloatOption>();
                    foreach (var item in ObjectConfig.plantInfoDic)
                    {
                        list.Add(new FloatOption(item.Value.itemName, () =>
                        {
                            map.SeedCode = item.Value.seedItem;
                            //可能的更新
                            command1.BindData("更改种植作物", ObjectConfig.GetPlantSprite(map.SeedCode));
                        }));
                    }
                    UIManager.Instance.ShowFloatOptions(list, RectTransformAnchor.BOTTOM_LEFT);
                });

                var command2 = AddCommand("删除种植区", null);
                command2.BindCommand(() =>
                {
                    Current.CurMap.DeleteSection(map);
                });

                var command3 = AddCommand("拓展种植区", null);
                command3.BindCommand(() =>
                {
                    InputController.Instance.MouseState = MouseState.ExpandZone;
                });

                var command4 = AddCommand("缩小种植区", null);
                command4.BindCommand(() =>
                {
                    InputController.Instance.MouseState = MouseState.ShrinkZone;
                });
            }
        }

        private DynamicCommandIcon AddCommand(string commandName, Sprite sprite)
        {
            var go = Instantiate(itemCommandGameObject, commandParent);
            go.GetComponent<DynamicCommandIcon>().BindData(commandName, sprite);
            return go.GetComponent<DynamicCommandIcon>();
        }
    }
}
