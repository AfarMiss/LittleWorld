using System;
using System.Reflection;

public class Singleton<T> where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var type = typeof(T);
                var ctors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);

                if (ctor == null)
                {
                    throw new Exception("Non Public Constructor Found in " + type.Name);
                }

                instance = ctor.Invoke(null) as T;

                instance.OnCreateInstance();
            }
            return instance;
        }
    }

    public virtual void Tick()
    {

    }

    public virtual void OnCreateInstance()
    {

    }

    public virtual void Dispose()
    {
        instance = null;
    }
}
