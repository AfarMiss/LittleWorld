using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Master : MonoBehaviour, ITrigger
    {
        private IEnumerator StartToRun()
        {
            yield return new WaitForSeconds(3);
            Debug.Log("女主人发出声响！");
            this.EventTrigger("女主人走动");
            yield return new WaitForSeconds(3);
            Debug.Log("女主人发出声响！");
            this.EventTrigger("女主人走动");
        }

        private void Start()
        {
            StartCoroutine(StartToRun());
        }
    }
}
