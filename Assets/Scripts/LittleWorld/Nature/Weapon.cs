using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Weapon : WorldObject
    {
        public WeaponInfo WeaponInfo;
        public bool finishCooldown = false;
        public float curCooldown;
        public bool isAiming = false;
        public WorldObject target;
        public Humanbeing Owner;
        public Weapon(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var weaponInfo))
            {
                this.WeaponInfo = weaponInfo as WeaponInfo;
                ItemName = weaponInfo.itemName;
                curCooldown = this.WeaponInfo.rangedCooldown;
            }
        }

        public void OnEquip(Humanbeing owner)
        {
            this.Owner = owner;
        }

        public void OnDispose()
        {
            this.Owner = null;
        }

        public override Sprite GetSprite()
        {
            return WeaponInfo.itemSprites[0];
        }

        public void Attack(WorldObject target)
        {
            Debug.LogWarning("开始攻击!");
            isAiming = true;
            this.target = target;
        }

        public override void Tick()
        {
            base.Tick();
            if (isAiming)
            {
                curCooldown -= GameSetting.TickTime;
            }
            else
            {
                curCooldown = this.WeaponInfo.rangedCooldown;
            }
            finishCooldown = curCooldown <= 0;

            TryFire();
            //Debug.Log($"curCooldown:{curCooldown},use hashCode:{GetHashCode()}");
        }

        private void TryFire()
        {
            if (!WeaponInfo.isMelee)
            {
                if (isAiming && finishCooldown)
                {
                    var bullet = PoolManager.Instance.GetNextObject(PoolEnum.Bullet.ToString());
                    bullet.transform.position = carriedParent.GridPos.To3();
                    bullet.GetComponent<Bullet>().Init((target.GridPos - carriedParent.GridPos).To3(), WeaponInfo.fireRate);
                    curCooldown = this.WeaponInfo.rangedCooldown;
                    isAiming = false;
                    target = null;
                }
            }
        }
    }
}
