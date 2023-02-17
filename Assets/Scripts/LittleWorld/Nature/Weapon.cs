using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Weapon : WorldObject
    {
        public WeaponInfo WeaponInfo;
        public Weapon(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var weaponInfo))
            {
                this.WeaponInfo = weaponInfo as WeaponInfo;
                ItemName = weaponInfo.itemName;
            }
        }

        public override Sprite GetSprite()
        {
            return WeaponInfo.itemSprites[0];
        }
    }
}
