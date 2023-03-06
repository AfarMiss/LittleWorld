using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 dir;
        private float speed;
        private Vector3 targetPos;
        private float runtime = -1;
        private float curRuntime = 0;
        private float damage;
        private void FixedUpdate()
        {
            curRuntime += Time.fixedDeltaTime;
            transform.position += Time.fixedDeltaTime * dir * speed;
            if (curRuntime >= runtime)
            {
                //伤害判定
                foreach (var item in WorldUtility.GetWorldObjectsAt(targetPos.ToCell()))
                {
                    if (item is Animal animal)
                    {
                        animal.BeHurt(damage);
                    }
                }

                curRuntime = 0;
                runtime = -1;
                ObjectPoolManager.Instance.Putback(PoolEnum.Bullet.ToString(), this.gameObject);
                Debug.Log($"回收子弹:hash:{GetHashCode()},pos:{this.transform.position}");
            }
        }

        public void Init(Vector3 targetPos, Vector3 originalPos, float speed, float damage)
        {
            this.targetPos = targetPos;
            var disatance = targetPos - originalPos;
            this.speed = speed;
            this.dir = disatance.normalized;
            this.runtime = disatance.magnitude / speed;
            this.damage = damage;
            Debug.Log($"生成子弹{GetHashCode()}:speed:{speed},targetPos:{targetPos},originalPos:{originalPos},pos:{this.transform.position}");
        }
    }
}
