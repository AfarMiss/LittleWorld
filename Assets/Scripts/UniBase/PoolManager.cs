﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    /// <summary>
    /// 对象池配置信息
    /// </summary>
    private Dictionary<string, Pool> poolInfo;
    /// <summary>
    /// 对象池队列,使用List是因为Queue在元素出栈后不好管理
    /// </summary>
    private Dictionary<int, List<PoolItem<GameObject>>> poolQueue;
    /// <summary>
    /// 默认父节点
    /// </summary>
    private Transform defaultParent;

    private PoolManager() { }

    public void CreatePool(int poolSize, GameObject poolPrefab, string poolName = null, Transform parent = null)
    {
        if (poolInfo == null)
        {
            poolInfo = new Dictionary<string, Pool>();
        }
        if (poolQueue == null)
        {
            poolQueue = new Dictionary<int, List<PoolItem<GameObject>>>();
        }

        if (poolInfo.ContainsKey(poolPrefab.GetInstanceID().ToString()))
        {
            return;
        }
        else
        {
            Pool pool = new Pool(poolSize, poolPrefab);
            if (poolName != null)
            {
                poolInfo.Add(poolName, pool);
            }
            else
            {
                poolInfo.Add(poolPrefab.GetInstanceID().ToString(), pool);
            }

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject go;
                Transform realParent = null;
                if (parent != null)
                {
                    realParent = parent;
                }
                else
                {
                    realParent = defaultParent;
                }
                go = GameObject.Instantiate(poolPrefab, realParent);
                go.SetActive(false);
                if (poolQueue.ContainsKey(poolPrefab.GetInstanceID()))
                {
                    poolQueue[poolPrefab.GetInstanceID()].Add(new PoolItem<GameObject>(go));
                }
                else
                {
                    poolQueue.Add(poolPrefab.GetInstanceID(), new List<PoolItem<GameObject>>());
                }

            }
        }
    }

    public PoolItem<T> Find<T>(Predicate<PoolItem<T>> match)
    {
        var allGameobjects = new List<PoolItem<T>>();
        //To convert the Keys to a List of their own:
        //listNumber = dicNumber.Select(kvp => kvp.Key).ToList();
        //Or you can shorten it up and not even bother using select:
        //listNumber = dicNumber.Keys.ToList();
        var values = poolQueue.Values;
        var valueList = values.ToList();
        foreach (var item in valueList)
        {
            allGameobjects.AddRange(item);
        }
        return allGameobjects.Find(match);
    }

    public GameObject GetNextObject(string key)
    {
        if (poolInfo.ContainsKey(key))
        {
            var curPool = poolInfo[key];
            if (poolQueue.ContainsKey(curPool.prefabId))
            {
                var curGo = poolQueue[curPool.prefabId].Find(x => !x.hasBeenUsed);
                curGo.poolInstance.SetActive(true);
                return curGo.poolInstance;
            }
            else
            {
                Debug.LogWarning($"No pool object for {key}");
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public void Putback(string key, GameObject curObject)
    {
        if (poolInfo.ContainsKey(key))
        {
            var curPool = poolInfo[key];
            if (poolQueue.ContainsKey(curPool.prefabId))
            {
                curObject.SetActive(false);
                var curPoolItem = poolQueue[curPool.prefabId].
                    Find(x =>
                    x.poolInstance.GetInstanceID()
                    == curObject.GetInstanceID());
                curPoolItem.hasBeenUsed = false;
            }
            else
            {
                GameObject.Destroy(curObject);
            }
        }

    }


    public override void Initialize()
    {
        base.Initialize();

        defaultParent = new GameObject().transform;
        defaultParent.name = "defaultPoolParent";
        GameObject.DontDestroyOnLoad(defaultParent);
    }
}
