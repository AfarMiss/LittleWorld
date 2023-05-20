using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public static class EventExtension
{
    public static void EventRegister(this IListener caller, string name, UnityAction action)
    {
        EventCenter.Instance.Register(name, action, caller);
    }

    public static void EventRegister<T>(this IListener caller, string name, UnityAction<T> action)
    {
        EventCenter.Instance.Register(name, action, caller);
    }

    public static void EventRegister<T1, T2>(this IListener caller, string name, UnityAction<T1, T2> action)
    {
        EventCenter.Instance.Register(name, action, caller);
    }

    public static void EventUnregister(this IListener listener)
    {
        EventCenter.Instance.EventUnregister(listener);
    }

    public static void EventTrigger(this ITrigger trigger, string eventName)
    {
        EventCenter.Instance.Trigger(eventName);
    }

    public static void EventTrigger<T>(this ITrigger trigger, string eventName, T param)
    {
        EventCenter.Instance.Trigger(eventName, param);
    }

    public static void EventTrigger<T1, T2>(this ITrigger trigger, string eventName, T1 p1, T2 p2)
    {
        EventCenter.Instance.Trigger(eventName, p1, p2);
    }

    public static void EventUnregister(this IListener caller, string name)
    {
        EventCenter.Instance.Unregister(name, caller);
    }
}

public interface IListener
{
}

public interface ITrigger
{
}

public interface IEventInfo
{
    void RemoveListener(IListener listener);
}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> actions;
    public Dictionary<object, UnityAction<T>> eventDic;

    public EventInfo(UnityAction<T> action, object caller)
    {
        this.actions += action;
        eventDic = new Dictionary<object, UnityAction<T>>();
        AddEvent(action, caller);
    }

    private void AddEvent(UnityAction<T> action, object caller)
    {
        if (eventDic.TryGetValue(caller, out var actions))
        {
            eventDic[caller] += action;
        }
        else
        {
            eventDic[caller] = action;
        }
    }

    public void RemoveListener(IListener caller)
    {
        eventDic.TryGetValue(caller, out var callerActions);
        this.actions -= callerActions;
    }
}

public class EventInfo<T1, T2> : IEventInfo
{
    public UnityAction<T1, T2> actions;
    public object caller;
    public Dictionary<object, UnityAction<T1, T2>> eventDic;

    public EventInfo(UnityAction<T1, T2> action, object caller)
    {
        this.actions += action;
        this.caller = caller;
        this.eventDic = new Dictionary<object, UnityAction<T1, T2>>();
        AddEvent(action, caller);
    }

    private void AddEvent(UnityAction<T1, T2> action, object caller)
    {
        if (eventDic.TryGetValue(caller, out var actions))
        {
            eventDic[caller] += action;
        }
        else
        {
            eventDic[caller] = action;
        }
    }

    public void RemoveListener(IListener caller)
    {
        eventDic.TryGetValue(caller, out var callerActions);
        this.actions -= callerActions;
    }
}


public class EventInfo : IEventInfo
{
    public UnityAction actions;
    public object caller;
    public Dictionary<object, UnityAction> eventDic;

    public EventInfo(UnityAction actions, object caller)
    {
        this.actions += actions;
        this.caller = caller;
        this.eventDic = new Dictionary<object, UnityAction>();
        AddEvent(actions, caller);
    }

    private void AddEvent(UnityAction action, object caller)
    {
        if (eventDic.TryGetValue(caller, out var actions))
        {
            eventDic[caller] += action;
        }
        else
        {
            eventDic[caller] = action;
        }
    }

    public void RemoveListener(IListener caller)
    {
        eventDic.TryGetValue(caller, out var callerActions);
        this.actions -= callerActions;
    }
}

public class EventCenter : Singleton<EventCenter>
{
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    public void Register<T1, T2>(string name, UnityAction<T1, T2> action, object caller)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T1, T2>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T1, T2>(action, caller));
        }
    }

    public void Register<T>(string name, UnityAction<T> action, object caller)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo<T>(action, caller));
        }
    }

    public void Register(string name, UnityAction action, object caller)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions += action;
        }
        else
        {
            eventDic.Add(name, new EventInfo(action, caller));
        }
    }

    public void Unregister<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }

    public void Unregister<T1, T2>(string name, UnityAction<T1, T2> action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T1, T2>).actions -= action;
        }
    }

    public void Unregister(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions -= action;
        }
    }

    public void Trigger<T>(string name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).actions?.Invoke(info);
        }
    }

    public void Trigger<T1, T2>(string name, T1 Param1, T2 Param2)
    {
        if (eventDic.ContainsKey(name))
        {
            if ((eventDic[name] as EventInfo<T1, T2>) == null)
            {
                Debug.LogError($"未注册对应{typeof(T1)},{typeof(T2)}的事件");
            }
            (eventDic[name] as EventInfo<T1, T2>).actions?.Invoke(Param1, Param2);
        }
    }

    public void Trigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).actions?.Invoke();
        }
    }

    public void Clear()
    {
        eventDic.Clear();
    }

    public void EventUnregister(IListener caller)
    {
        foreach (var item in eventDic)
        {
            item.Value.RemoveListener(caller);
        }
    }

    public void Unregister(string eventName, IListener caller)
    {
        foreach (var item in eventDic)
        {
            if (item.Key == eventName)
            {
                item.Value.RemoveListener(caller);
            }
        }
    }

    private EventCenter()
    {

    }
}
