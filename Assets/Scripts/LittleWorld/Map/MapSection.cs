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
        public SectionType sectionType;
        public int sectionColorIndex;
        public int sectionID;

        public MapSection(List<MapGridDetails> gridIndexs, SectionType sectionType, int sectionColorIndex)
        {
            this.grids = gridIndexs;
            this.sectionType = sectionType;
            this.sectionColorIndex = sectionColorIndex;
            this.sectionID = SectionIDSeed++;
            this.sectionName = $"{sectionType.ToString()}_{sectionID}";
        }


    }

    public enum SectionType
    {
        PLANT,
        STORE,
    }
}
