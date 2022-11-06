using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    public Action OnFinish;
    public bool usingPool;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            OnFinish?.Invoke();
        }
    }

    public void Init(Action OnFinish, bool usingPool)
    {
        this.OnFinish = OnFinish;
        this.usingPool = usingPool;
    }
}
