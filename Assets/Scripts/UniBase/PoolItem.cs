using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItem<T>
{
    public T poolInstance;
    public bool hasBeenUsed;

    public PoolItem(T poolInstance, bool hasBeenUsed = false)
    {
        this.poolInstance = poolInstance;
        this.hasBeenUsed = hasBeenUsed;
    }
}
