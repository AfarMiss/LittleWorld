using LittleWorld.Command;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using SRF;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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

        public void BindBriefInfo(Item.Object[] objects)
        {
            if (objects.Length > 1)
            {
                var objectDic = new Dictionary<Type, int>();
                foreach (Item.Object obj in objects)
                {
                    if (objectDic.ContainsKey(obj.GetType()))
                    {
                        objectDic[obj.GetType()]++;
                    }
                    else
                    {
                        objectDic.Add(obj.GetType(), 1);
                    }
                }
                if (objectDic.Count > 1)
                {
                    InfoTitle.text = "多种x" + objects.Length;
                }
                else if (objectDic.Count > 0)
                {
                    InfoTitle.text = $"{(objects[0] as WorldObject).ItemName}x{objects.Length}";
                }
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
                    foreach (var item in ObjectConfig.ObjectInfoDic)
                    {
                        if (item.Value is PlantInfo)
                        {
                            list.Add(new FloatOption(item.Value.itemName, () =>
                            {
                                map.SeedCode = (item.Value as PlantInfo).seedItem;
                                //可能的更新
                                command1.BindData("更改种植作物", ObjectConfig.GetPlantSprite(map.SeedCode));
                            }));
                        }
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
            if (item is StorageMapSection storage)
            {
                var command2 = AddCommand("删除存储区", null);
                command2.BindCommand(() =>
                {
                    Current.CurMap.DeleteSection(storage);
                });

                var command3 = AddCommand("拓展存储区", null);
                command3.BindCommand(() =>
                {
                    InputController.Instance.MouseState = MouseState.ExpandZone;
                });

                var command4 = AddCommand("缩小存储区", null);
                command4.BindCommand(() =>
                {
                    InputController.Instance.MouseState = MouseState.ShrinkZone;
                });
            }
            if (item is Humanbeing humanbeing)
            {
                if (humanbeing.gearTracer.curWeapon != null)
                {
                    var command2 = AddCommand("开火", null);
                    command2.BindCommand(() =>
                    {
                        CommandCenter.Instance.Enqueue(new ChangeMouseStateCommand(MouseState.ReadyToFire));
                    });
                }
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
