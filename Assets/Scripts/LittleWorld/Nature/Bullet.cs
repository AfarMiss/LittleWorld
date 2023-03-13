using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageInfo = System.Tuple<LittleWorld.Item.Animal, LittleWorld.Item.Humanbeing>;

namespace LittleWorld.Item
{
    public class Bullet : MonoBehaviour
    {
        public class DamageInfo
        {
            public Animal animal;
            public Humanbeing humanbeing;
        }

        private Vector3 dir;
        private float speed;
        private Vector3 targetPos;
        private float runtime = -1;
        private float curRuntime = 0;
        private float damage;
        private Humanbeing owner;
        private void FixedUpdate()
        {
            curRuntime += Time.fixedDeltaTime;
            transform.position += Time.fixedDeltaTime * dir * speed;
            Debug.Log($"curRuntime:{curRuntime},runtime:{runtime}");
            if (curRuntime >= runtime)
            {
                //伤害判定
                foreach (var item in WorldUtility.GetObjectsAtCell(targetPos.ToCell()))
                {
                    if (item is Animal animal)
                    {
                        animal.BeHurt(damage * 3, this.owner);
                    }
                }

                curRuntime = 0;
                runtime = -1;
                ObjectPoolManager.Instance.Putback(PoolEnum.Bullet.ToString(), this.gameObject);
                Debug.Log($"回收子弹:hash:{GetHashCode()},pos:{this.transform.position}");
            }
        }

        public void Init(Vector3 targetPos, Vector3 originalPos, float speed, float damage, Humanbeing owner)
        {
            this.targetPos = targetPos;
            var disatance = targetPos - originalPos;
            this.speed = speed;
            this.dir = disatance.normalized;
            this.runtime = disatance.magnitude / speed;
            this.damage = damage;
            this.owner = owner;
            Debug.Log($"生成子弹{GetHashCode()}:speed:{speed},targetPos:{targetPos},originalPos:{originalPos},pos:{this.transform.position}");
        }
    }
}
