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
        private void FixedUpdate()
        {
            transform.position += Time.fixedDeltaTime * dir * speed;
        }

        public void Init(Vector3 targetPos, Vector3 originalPos, float speed)
        {
            var dir = targetPos - originalPos;
            this.speed = speed;
            this.dir = dir.normalized;
        }

        private void Start()
        {
            StartCoroutine(DestroySelf());
        }

        IEnumerator DestroySelf()
        {
            if (Vector3.Distance(this.transform.position, targetPos) > 0.05f)
            {
                yield return null;
            }
            ObjectPoolManager.Instance.Putback(PoolEnum.Bullet.ToString(), this.gameObject);
        }
    }
}
