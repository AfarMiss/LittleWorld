using LittleWorld.MapUtility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LittleWorld.UI;
using LittleWorld.Message;

namespace LittleWorld.Item
{
    public abstract class WorldObject : Object
    {
        public bool isCarried = false;
        public bool canPile = false;
        public WorldObject carriedParent = null;
        protected float maxHealth;
        public float mass;

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
            this.instanceID = SceneObjectManager.ItemInstanceID++;
            mapBelongTo = map ?? MapManager.Instance.ColonyMap;

            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var plantInfo))
            {
                canPile = plantInfo.canPile;
            }
            mapBelongTo.DropdownWorldObjectAt(gridPos, this);
            SceneObjectManager.Instance.RegisterItem(this);
        }

        public void OnBeDropDown()
        {
            mapBelongTo.DropdownWorldObjectAt(carriedParent.gridPos, this);
            isCarried = false;
            carriedParent = null;
        }

        public void Destroy()
        {
            if (this.canPile)
            {
                this.mapBelongTo.GetGrid(this.gridPos, out var result);
                result.DeleteSinglePiledThing();
            }
            SceneObjectManager.Instance.UnregisterItem(this);
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