using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class PlantMapSection : MapSection
    {
        public int SeedCode
        {
            get
            {
                return seedCode;
            }
            set
            {
                seedCode = value;
                EventCenter.Instance.Trigger<int>(EventEnum.UI_UPDATE_PLANT_CODE.ToString(), seedCode);
            }
        }
        private int seedCode;
        public bool CanHarvest
        {
            get
            {
                foreach (var grid in grids)
                {
                    if (grid.HasPlant && grid.Plant.IsRipe)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public PlantMapSection(List<MapGridDetails> gridIndexs, int sectionColorIndex) : base(gridIndexs, sectionColorIndex)
        {
            ItemName = "种植区";
            var seedInfo = ObjectConfig.ObjectInfoDic.Values.ToList().Find(x => x is SeedInfo);
            if (seedInfo != null)
            {
                SeedCode = seedInfo.itemCode;
            }
        }
    }
}
