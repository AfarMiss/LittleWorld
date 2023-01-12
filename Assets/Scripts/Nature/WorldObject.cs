using System.Collections.Generic;
using UnityEngine;

namespace LittleWorldObject
{
    public class WorldObject
    {
        public int instanceID;
        public WorldObject(Vector3Int gridPos)
        {
            this.gridPos = gridPos;
            this.instanceID = SceneItemsManager.ItemInstanceID++;
        }

        protected float maxHealth;
        protected float curHealth;

        protected string ItemName;
        public Vector3Int gridPos;

        public Vector3Int GridPos { get => gridPos; set => gridPos = value; }

        public virtual void ShowBriefInfo()
        {
            var briefPanel = UIManager.Instance.Show<BriefInfoPanel>(UIType.PANEL, UIPath.Panel_BriefInfoPanel.ToString());
            briefPanel.BindBriefInfo(
                ItemName,
                new List<BriefInfo>()
            {
                new BriefInfo("生命值",$"{curHealth.ToString()}/{maxHealth.ToString()}")
            });
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