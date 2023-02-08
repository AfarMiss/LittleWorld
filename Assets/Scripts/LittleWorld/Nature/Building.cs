using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Building : WorldObject
    {
        public BuildingInfo buildingInfo;
        public BuildingStatus buildingStatus;
        public int curHitPoint;

        public Building(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
        }

        public override Sprite GetSprite()
        {
            return buildingInfo.itemSprites[0];
        }
    }

    public enum BuildingStatus
    {
        Done,
        Unfinished,
    }
}
