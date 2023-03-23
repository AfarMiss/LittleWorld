using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace LittleWorld.Jobs
{
    public class HuntUtil
    {
        private static bool CanHunt(Vector2 huntPos, Vector2Int targetPos, WeaponInfo weaponInfo)
        {
            var canHunt = Vector2.Distance(huntPos, targetPos) <= weaponInfo.range;
            if (canHunt)
            {
                Debug.LogWarning("可以狩猎!");
            }
            else
            {
                Debug.LogWarning("不可以狩猎!超出射程");
            }
            return canHunt;
        }
    }
}
