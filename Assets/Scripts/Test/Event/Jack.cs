using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Jack : MonoBehaviour, IListener
    {
        private void Start()
        {
            Debug.Log("注册监听！");
            this.EventRegister("Tom走动", () =>
            {
                Debug.Log("向Tom走去");
            });
            this.EventRegister("女主人走动", () =>
            {
                Debug.Log("开始捕鼠");
            });
            StartCoroutine(CancelListen());
            StartCoroutine(CancelListen());
        }

        private IEnumerator CancelListen()
        {
            yield return new WaitForSeconds(4);
            Debug.Log("取消监听Tom！");
            this.EventUnregister("Tom走动");
        }
    }
}
