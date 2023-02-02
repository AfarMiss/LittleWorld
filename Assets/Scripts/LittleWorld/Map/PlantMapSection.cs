using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class PlantMapSection : MapSection
    {
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
        }
    }
}
