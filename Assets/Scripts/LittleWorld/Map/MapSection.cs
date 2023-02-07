using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class MapSection : Item.Object
    {
        public static int SectionIDSeed = 0;
        public List<MapGridDetails> grids;
        public List<Vector2Int> GridPosList
        {
            get
            {
                var result = new List<Vector2Int>();
                foreach (var item in grids)
                {
                    result.Add(item.pos);
                }
                return result;
            }
        }
        public string sectionName;
        public int sectionColorIndex;
        public int sectionID;

        public MapSection(List<MapGridDetails> gridIndexs, int sectionColorIndex)
        {
            this.grids = gridIndexs;
            this.sectionColorIndex = sectionColorIndex;
            this.sectionID = SectionIDSeed++;
        }


    }

    public enum SectionType
    {
        PLANT,
        STORE,
    }
}
