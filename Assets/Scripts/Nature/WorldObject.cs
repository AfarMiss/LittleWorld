using System.Collections.Generic;
using UnityEngine;

namespace LittleWorldObject
{
    public class WorldObject
    {
        protected float maxHealth;
        protected float curHealth;

        protected string ItemName;

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

    }
}