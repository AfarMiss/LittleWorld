using LittleWorld.MapUtility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.Object
{
    public class WorldObject
    {
        public int instanceID;
        public WorldObject(Vector3Int gridPos, Map map = null)
        {
            this.gridPos = gridPos;
            this.instanceID = SceneItemsManager.ItemInstanceID++;
            curMap = map ?? MapManager.Instance.ColonyMap;
        }

        protected float maxHealth;
        protected float curHealth;

        protected string ItemName;
        public float mass;
        protected Vector3Int gridPos;
        public Map curMap;
        public Vector3 RenderPos
        {
            get
            {
                if (this as Humanbeing != null)
                {
                    var navis = GameObject.FindObjectsOfType<PathNavigationOnly>();
                    var humanNavi = navis.ToList().Find(x => x.humanID == instanceID);
                    return humanNavi != null ? humanNavi.renderPos : gridPos;
                }
                else
                {
                    return gridPos;
                }
            }
        }

        public Vector3Int GridPos { get => gridPos; set => gridPos = value; }

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