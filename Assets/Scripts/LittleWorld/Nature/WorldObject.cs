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
        public bool isCarried = false;
        public bool canPile = false;
        public WorldObject carriedParent = null;
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
                canPile = plantInfo.canPile;
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
            OnDestroy();
            if (this.canPile && !inBuildingConstruction)
            {
                this.mapBelongTo.TryGetGrid(this.gridPos, out var result);
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
                if (this is Humanbeing)
                {
                    var navis = GameObject.FindObjectsOfType<PathNavigation>();
                    var humanNavi = navis.ToList().Find(x => x.humanID == instanceID);
                    return humanNavi != null ? humanNavi.renderPos : gridPos;
                }
                else
                {
                    return GridPos.To3();
                }
            }
        }

        public static void ShowInfo(Object[] objects)
        {
            var briefPanel = UIManager.Instance.Show<BriefInfoPanel>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
            briefPanel.BindBriefInfo(objects);
        }

        public static void ShowInfo(Object objects)
        {
            var briefPanel = UIManager.Instance.Show<BriefInfoPanel>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
            briefPanel.BindBriefInfo(new LittleWorld.Item.Object[] { objects });
        }

        public virtual void Tick()
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