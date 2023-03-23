using LittleWorld.MapUtility;
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
            if (!isAiming)
            {
                Debug.LogWarning("开始攻击!");
                curCooldown = this.WeaponInfo.rangedCooldown;
                isAiming = true;
                this.target = target;
            }
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
        }

        private void TryFire()
        {
            if (!WeaponInfo.isMelee)
            {
                if (isAiming && finishCooldown)
                {
                    var bullet = ObjectPoolManager.Instance.GetNextObject(PoolEnum.Bullet.ToString());
                    bullet.transform.position = carriedParent.GridPos.To3();
                    bullet.GetComponent<Bullet>().Init(
                        target.GridPos.To3(),
                        carriedParent.GridPos.To3(),
                        WeaponInfo.fireRate,
                        WeaponInfo.meleeDamage,
                        this.Owner
                        );
                    curCooldown = this.WeaponInfo.rangedCooldown;
                    isAiming = false;
                    target = null;
                }
            }
        }

        public void StopFire()
        {
            if (isAiming)
            {
                isAiming = false;
                curCooldown = this.WeaponInfo.rangedCooldown;
                this.target = null;
            }
        }
    }
}
