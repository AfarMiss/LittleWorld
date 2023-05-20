using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Tom : MonoBehaviour, ITrigger
    {
        private IEnumerator StartToRun()
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Tom发出声响！");
            this.EventTrigger("Tom走动");
            yield return new WaitForSeconds(3);
            Debug.Log("Tom发出声响！");
            this.EventTrigger("Tom走动");
        }

        private void Start()
        {
            StartCoroutine(StartToRun());
        }
    }
}
