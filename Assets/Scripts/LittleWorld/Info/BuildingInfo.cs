using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class BuildingInfo : BaseInfo
    {
        public string itemType;
        public float mass;
        public int buildingWorkAmount;
        public float marketValue;
        public int maxHitPoint;
        public List<BuildingCost> buildingCost;
    }

    public class BuildingCost
    {
        public int materialCode;
        public int materCount;

        public BuildingCost(int materialCode, int materCount)
        {
            this.materialCode = materialCode;
            this.materCount = materCount;
        }
    }
}
