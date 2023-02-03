using LittleWorld.MapUtility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LittleWorld.UI;

namespace LittleWorld.Item
{
    public abstract class WorldObject : Object
    {
        public int itemCode;
        public int instanceID;
        protected float maxHealth;
        protected string ItemName;
        public float mass;

        protected float curHealth;
        public Map curMap;

        protected Vector2Int gridPos;

        public abstract Sprite GetSprite();

        public Vector2Int GridPos { get => gridPos; set => gridPos = value; }

        public WorldObject(int itemCode, Vector2Int gridPos, Map map = null)
        {
            this.gridPos = gridPos;
            this.itemCode = itemCode;
            this.instanceID = SceneObjectManager.ItemInstanceID++;
            curMap = map ?? MapManager.Instance.ColonyMap;
            SceneObjectManager.Instance.RegisterItem(this);
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
        public virtual void ShowBriefInfo()
        {
            var briefPanel = UIManager.Instance.Show<BriefInfoElement>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
            briefPanel.BindBriefInfo(
                ItemName,
                new List<BriefInfo>()
            {
                new BriefInfo("生命值",$"{curHealth.ToString()}/{maxHealth.ToString()}")
            });
        }

        public static void ShowMultiInfo(int multiCount)
        {
            var briefPanel = UIManager.Instance.Show<BriefInfoElement>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
            briefPanel.BindBriefInfo(
                $"多种x{multiCount}",
                null);
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