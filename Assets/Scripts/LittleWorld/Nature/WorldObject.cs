using LittleWorld.MapUtility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LittleWorld.UI;

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

        public Vector2Int GridPos { get => gridPos; set { gridPos = value; } }

        public WorldObject(int itemCode, Vector2Int gridPos, Map map = null)
        {
            this.itemCode = itemCode;
            this.instanceID = SceneObjectManager.ItemInstanceID++;
            mapBelongTo = map ?? MapManager.Instance.ColonyMap;
            this.gridPos = gridPos;
            SceneObjectManager.Instance.RegisterItem(this);
        }

        public void OnBeCarried(WorldObject wo)
        {
            isCarried = true;
            carriedParent = wo;
        }

        public void OnBeDropDown()
        {
            this.gridPos = carriedParent.GridPos;
            isCarried = false;
            carriedParent = null;
        }

        public void Destroy()
        {
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