using LittleWorld.MapUtility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LittleWorld.UI;
using LittleWorld.Message;
using Unity.VisualScripting;

namespace LittleWorld.Item
{
    public abstract class WorldObject : Object
    {
        public bool isDestroyed = false;
        public bool isCarried = false;
        public bool canPile = false;
        public WorldObject carriedParent = null;
        /// <summary>
        /// 处于建造蓝图中
        /// </summary>
        public bool inBuildingConstruction = false;

        protected float curHealth;
        public Map mapBelongTo;

        protected Vector2Int gridPos;

        public abstract Sprite GetSprite();

        public Vector2Int GridPos
        {
            get => gridPos;
            set
            {
                var lastPos = gridPos;
                gridPos = value;
                EventCenter.Instance.Trigger(EventName.OBJECT_GRID_CHANGE, new ChangeGridMessage(lastPos, this));
            }
        }

        public WorldObject(int itemCode, Vector2Int gridPos, Map map = null)
        {
            this.itemCode = itemCode;
            this.ItemName = ObjectConfig.GetInfo(itemCode)?.itemName;
            this.instanceID = SceneObjectManager.ItemInstanceID++;
            mapBelongTo = map ?? MapManager.Instance.ColonyMap;

            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var plantInfo))
            {
                canPile = plantInfo.CanPile;
            }
            mapBelongTo.DropDownWorldObjectAt(gridPos, this);
            SceneObjectManager.Instance.RegisterObject(this);
        }

        public void OnBeDropDown()
        {
            var referencePoint = carriedParent.gridPos;
            mapBelongTo.DropDownWorldObjectAt(referencePoint, this);
            isCarried = false;
            carriedParent = null;
        }

        public void OnBeBluePrint()
        {
            var referencePoint = carriedParent.gridPos;
            mapBelongTo.AddBlueprintObjectAt(referencePoint, this);
            isCarried = false;
            inBuildingConstruction = true;
            carriedParent = null;
        }

        public void Destroy()
        {
            isDestroyed = true;
            OnDestroy();
            if (this.canPile && !inBuildingConstruction)
            {
                this.mapBelongTo.GetGrid(this.gridPos, out var result);
                result.DeleteSinglePiledThing();
            }
            SceneObjectManager.Instance.UnregisterObject(this);
        }

        protected virtual void OnDestroy()
        {

        }

        public Vector3 RenderPos
        {
            get
            {
                if (this is Animal animal)
                {
                    return animal.RenderTracer.RenderPos;
                }
                else
                {
                    return GridPos.To3();
                }
            }
        }

        /// <summary>
        /// 以渲染锚点为中心，边长为1的正方形
        /// </summary>
        public Rect EntityRect
        {
            get
            {
                return new Rect(RenderPos.To2(), Vector2.one);
            }
        }

        public static void ShowInfo(Object[] objects)
        {
            UIManager.Instance.HideAllInfoPanel();
            if (objects.Length <= 0)
            {
                return;
            }
            if (objects.Length > 1)
            {
                var briefPanel = UIManager.Instance.Show<BriefInfoPanel>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
                briefPanel.BindBriefInfo(objects);
            }
            else if (objects.Length == 1)
            {
                ShowInfo(objects[0]);
            }
        }

        public static void ShowInfo(Object o)
        {
            BriefInfoPanel briefInfoPanel;
            if (o is Animal)
            {
                briefInfoPanel = UIManager.Instance.Show<BriefInfoAnimalPanel>(UIType.PANEL, UIPath.Panel_BriefInfoAnimalPanel);
                briefInfoPanel.BindBriefInfo(o);
            }
            else
            {
                briefInfoPanel = UIManager.Instance.Show<BriefInfoPanel>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
                briefInfoPanel.BindBriefInfo(o);
            }
        }

        public virtual void Tick()
        {

        }

        public virtual void RealTimeTick()
        {

        }

        public virtual List<FloatOption> AddFloatMenu()
        {
            return null;
        }

        public virtual void OnStart()
        {

        }

    }
}