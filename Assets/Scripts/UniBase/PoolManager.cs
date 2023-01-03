using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    /// <summary>
    /// 对象池配置
    /// </summary>
    private Dictionary<string, Pool> poolInfo;
    /// <summary>
    /// 对象池父节点
    /// </summary>
    //private Transform objectPoolTransform;
    /// <summary>
    /// 对象池队列
    /// </summary>
    private Dictionary<int, Queue<GameObject>> poolQueue;

    public void CreatePool(int poolSize, GameObject poolPrefab, string poolName = null, Transform parent = null)
    {
        if (poolInfo == null)
        {
            poolInfo = new Dictionary<string, Pool>();
        }
        if (poolQueue == null)
        {
            poolQueue = new Dictionary<int, Queue<GameObject>>();
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
                    realParent = transform;
                }
                go = Instantiate(poolPrefab, realParent);
                go.SetActive(false);
                if (poolQueue.ContainsKey(poolPrefab.GetInstanceID()))
                {
                    poolQueue[poolPrefab.GetInstanceID()].Enqueue(go);
                }
                else
                {
                    poolQueue.Add(poolPrefab.GetInstanceID(), new Queue<GameObject>());
                }

            }
        }
    }

    public GameObject GetNextObject(string key)
    {
        if (poolInfo.ContainsKey(key))
        {
            var curPool = poolInfo[key];
            if (poolQueue.ContainsKey(curPool.prefabId))
            {
                var curGo = poolQueue[curPool.prefabId].Dequeue();
                curGo.SetActive(true);
                return curGo;
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
                poolQueue[curPool.prefabId].Enqueue(curObject);
            }
            else
            {
                Destroy(curObject);
            }
        }

    }
}
