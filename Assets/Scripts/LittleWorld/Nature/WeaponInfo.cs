using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class WeaponInfo : BaseInfo
    {
        public string itemType;
        public float mass;
        public float marketValue;
        public int maxHitPoint;
        public int createAt;
        public int workToMake;
        public int burstShotCount;
        public string caliber;
        public float fireRate;
        public int magazineCapacity;
        public float reloadTime;
        public float spread;
        public float weaponSway;
        public float meleeDamage;
        public float range;
        public float rangedCooldown;
        public float aimingTime;
        public float buildingDamageFactor;
        public bool isMelee;
    }
}
