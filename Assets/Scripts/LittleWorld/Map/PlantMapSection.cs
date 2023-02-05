using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class PlantMapSection : MapSection
    {
        public int SeedCode;
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
