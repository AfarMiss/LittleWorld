using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class MapSection
    {
        public static int SectionIDSeed = 0;
        public List<MapGridDetails> gridIndexs;
        public List<Vector2Int> gridVector
        {
            get
            {
                var result = new List<Vector2Int>();
                foreach (var item in gridIndexs)
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

        public MapSection(List<MapGridDetails> gridIndexs, string sectionName, SectionType sectionType, int sectionColorIndex)
        {
            this.gridIndexs = gridIndexs;
            this.sectionName = sectionName;
            this.sectionType = sectionType;
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
