using LittleWorld.MapUtility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Item
{
    public class WorldObject : Object
    {
        public int itemCode;
        public int instanceID;
        public WorldObject(Vector2Int gridPos, Map map = null)
        {
            this.gridPos = gridPos;
            this.instanceID = SceneItemsManager.ItemInstanceID++;
            curMap = map ?? MapManager.Instance.ColonyMap;
        }

        protected float maxHealth;
        protected float curHealth;

        protected string ItemName;
        public float mass;
        protected Vector2Int gridPos;
        public Map curMap;
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

        public Vector2Int GridPos { get => gridPos; set => gridPos = value; }

        public virtual void ShowBriefInfo()
        {
            var briefPanel = UIManager.Instance.Show<BriefInfoPanel>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
            briefPanel.BindBriefInfo(
                ItemName,
                new List<BriefInfo>()
            {
                new BriefInfo("生命值",$"{curHealth.ToString()}/{maxHealth.ToString()}")
            });
        }

        public static void ShowMultiInfo(int multiCount)
        {
            var briefPanel = UIManager.Instance.Show<BriefInfoPanel>(UIType.PANEL, UIPath.Panel_BriefInfoPanel);
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