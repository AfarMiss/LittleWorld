using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
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

    /// <summary>
    /// 已经拥有实例
    /// </summary>
    public static bool hasInstance
    {
        get { return instance != null; }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}