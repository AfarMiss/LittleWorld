using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolTest : MonoBehaviour
{
    public int generateNum;
    public bool usePool = false;
    public GameObject cube;
    private ObjectPool<GameObject> pool;

    private void Start()
    {
        pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestoryGameObject, true, 5000, 10000);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < generateNum; i++)
        {
            if (usePool)
            {
                pool.Get();
            }
            else
            {
                var go = Instantiate(cube, UnityEngine.Random.insideUnitSphere, Quaternion.identity);
                go.GetComponent<CubeTest>().Init(() => Destroy(go), false);
            }
        }
    }

    private void OnDestoryGameObject(GameObject obj)
    {
        Destroy(obj);
    }

    private void OnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnGet(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.position = UnityEngine.Random.insideUnitSphere;
    }

    private GameObject OnCreate()
    {
        var go = Instantiate(cube, UnityEngine.Random.insideUnitSphere, Quaternion.identity);
        go.GetComponent<CubeTest>().Init(() => pool.Release(go), true);
        return go;
    }
}
