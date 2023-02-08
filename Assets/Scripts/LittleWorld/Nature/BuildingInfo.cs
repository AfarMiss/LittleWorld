using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class BuildingInfo
    {
        public int itemCode;
        public string itemName;
        public string itemType;
        public float mass;
        public int buildingWorkAmount;
        public float marketValue;
        public int maxHitPoint;
        public List<Sprite> itemSprites;
        public List<BuildingCost> buildingCost;
    }

    public class BuildingCost
    {
        public int materialCode;
        public int materCount;
    }
}
