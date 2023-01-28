using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class MapSection
    {
        public List<Vector2Int> gridIndexs;
        public string sectionName;
        public SectionType sectionType;
        public int sectionColorIndex;

        public MapSection(List<Vector2Int> gridIndexs, string sectionName, SectionType sectionType, int sectionColorIndex)
        {
            this.gridIndexs = gridIndexs;
            this.sectionName = sectionName;
            this.sectionType = sectionType;
            this.sectionColorIndex = sectionColorIndex;
        }


    }

    public enum SectionType
    {
        PLANT,
        STORE,
    }
}
