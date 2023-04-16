using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Ore : WorldObject
    {
        public OreInfo OreInfo;
        public int curHitPoint;
        public int ProductionCode => OreInfo.productionCode;
        public int ProductionAmount => OreInfo.productionAmount;

        public Ore(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var OreInfo))
            {
                this.OreInfo = OreInfo as OreInfo;
                ItemName = OreInfo.itemName;
            }
        }

        public override Sprite GetSprite()
        {
            return OreInfo.ItemSprites[0];
        }
    }
}
