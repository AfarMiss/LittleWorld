using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 dir;
        private float speed;
        private void FixedUpdate()
        {
            transform.position += Time.fixedDeltaTime * dir * speed;
        }

        public void Init(Vector3 dir, float speed)
        {
            this.speed = speed;
            this.dir = dir.normalized;
        }

        private void Start()
        {
            StartCoroutine(DestroySelf());
        }

        IEnumerator DestroySelf()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
