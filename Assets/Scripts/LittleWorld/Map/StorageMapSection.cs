using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.MapUtility
{
    public class StorageMapSection : MapSection
    {
        public StorageMapSection(List<MapGridDetails> gridIndexs, int sectionColorIndex) : base(gridIndexs, sectionColorIndex)
        {
            ItemName = "存储区";
        }
    }
}
