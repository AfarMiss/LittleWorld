using LittleWorld.MapUtility;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Weapon : WorldObject
    {
        public WeaponInfo WeaponInfo;
        public bool finishCooldown = false;
        public bool isAiming = false;
        public WorldObject target;
        public Animal Owner;
        public Weapon(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            if (ObjectConfig.ObjectInfoDic.TryGetValue(itemCode, out var weaponInfo))
            {
                this.WeaponInfo = weaponInfo as WeaponInfo;
                ItemName = weaponInfo.itemName;
            }
        }

        public void OnEquip(Animal owner)
        {
            this.Owner = owner;
        }

        public void OnDispose()
        {
            this.Owner = null;
        }

        public override Sprite GetCurrentSprite()
        {
            return WeaponInfo.ItemSprites[0];
        }

        public void Attack(WorldObject target)
        {
            TimerManager.Instance.RegisterTimer(new Timer(TimerName.ATTACK, WeaponInfo.rangedCooldown, () =>
            {
                Debug.LogWarning("开始攻击!");
                isAiming = true;
                this.target = target;
            },
            TryFire,
            null,
            ETimerType.Continous,
            Owner.instanceID));
        }

        public void CancelAttack()
        {
            TimerManager.Instance.UnregisterTimer(Owner.instanceID, TimerName.ATTACK);
            StopFire();
        }

        private void TryFire()
        {
            if (!WeaponInfo.isMelee)
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
                StopFire();
            }
        }

        public void StopFire()
        {

            isAiming = false;
            this.target = null;
        }
    }
}
