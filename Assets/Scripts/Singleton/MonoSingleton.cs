using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static bool AppIsQuit;
    private static T instance;
    public static T Instance
    {
        get
        {
            if (AppIsQuit)
            {
                return null;
            }
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

    public virtual void Initialize()
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
            //如果使用instance = this as T;会遇到this挂载的gameobject如果同时挂载了别的脚本，as关键字无法分析this类型的情况
            instance = this.gameObject.GetComponent<T>();
            AppIsQuit = false;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        AppIsQuit = true;
    }
}