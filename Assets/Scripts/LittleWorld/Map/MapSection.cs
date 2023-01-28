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

        public MapSection(List<Vector2Int> gridIndexs, string sectionName, SectionType sectionType)
        {
            this.gridIndexs = gridIndexs;
            this.sectionName = sectionName;
            this.sectionType = sectionType;
        }
    }

    public enum SectionType
    {
        PLANT,
        STORE,
    }
}
