using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Building
    {
        public BuildingInfo buildingInfo;
        public BuildingStatus buildingStatus;
        public int curHitPoint;
    }

    public enum BuildingStatus
    {
        Done,
        Building,
    }
}
