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
        public WorldObject carriedParent = null;
        protected float maxHealth;
        public float mass;

        protected float curHealth;
        public Map curMap;

        protected Vector2Int gridPos;

        public abstract Sprite GetSprite();

        public Vector2Int GridPos { get => gridPos; set { gridPos = value; } }

        public WorldObject(int itemCode, Vector2Int gridPos, Map map = null)
        {
            this.gridPos = gridPos;
            this.itemCode = itemCode;
            this.instanceID = SceneObjectManager.ItemInstanceID++;
            curMap = map ?? MapManager.Instance.ColonyMap;
            SceneObjectManager.Instance.RegisterItem(this);
        }

        public void OnBeCarried(WorldObject wo)
        {
            isCarried = true;
            carriedParent = wo;
        }

        public void OnBeDropDown()
        {
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
                if (this as Humanbeing != null)
                {
                    var navis = GameObject.FindObjectsOfType<PathNavigation>();
                    var humanNavi = navis.ToList().Find(x => x.humanID == instanceID);
                    return humanNavi != null ? humanNavi.renderPos : gridPos;
                }
                else
                {
                    return gridPos.To3();
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