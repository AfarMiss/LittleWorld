using System.Collections;
using System.Collections.Generic;
using Xml;

namespace LittleWorld.Item
{
    public class BuildingInfo : BaseInfo
    {
        public float mass;
        public int buildingWorkAmount;
        public float marketValue;
        public int maxHitPoint;
        public int layer;
        public Dictionary<int, int> BuildingCost
        {
            get
            {
                if (realBuildingCost == null)
                {
                    realBuildingCost = XmlUtility.GetBuildingCost(buildingCost);
                }
                return realBuildingCost;
            }
        }
        public Dictionary<int, int> realBuildingCost;
        public string buildingCost;
        public int buildingWidth;
        public int buildingLength;
        public int deconstructWorkAmount;
    }

    public class BuildingCost
    {
        public int materialCode;
        public int materialAmount;

        public BuildingCost(int materialCode, int materCount)
        {
            this.materialCode = materialCode;
            this.materialAmount = materCount;
        }
    }
}
