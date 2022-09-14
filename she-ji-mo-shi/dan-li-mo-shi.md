# 单例模式

## 普通单例

```
public class Singleton<T> where T : new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null) instance = new T();
            return instance;
        }
    }
}
```

## Unity下的Mono单例

```
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    var go = new GameObject($"[MonoSingleton]{typeof(T).Name}");
                    instance = go.AddComponent<T>();
                }
                DontDestroyOnLoad(instance);
            }

            return instance;
        }
    }
}

```

网络中有些版本实现了[线程锁](https://blog.csdn.net/xdedzl/article/details/85039761)这里暂时不考虑[线程安全](https://www.jianshu.com/p/854649bc0ce6)的问题。
