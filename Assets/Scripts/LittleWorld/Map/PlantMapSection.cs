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
            SeedCode = ObjectConfig.seedInfo.ElementAt(0).Value.itemCode;
        }
    }
}
