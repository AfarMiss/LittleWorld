using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleWorld
{
    public class TimerManager : Singleton<TimerManager>
    {
        public Dictionary<int, List<Timer>> timerDic;

        private TimerManager()
        {
        }

        public override void OnCreateInstance()
        {
            base.OnCreateInstance();
            timerDic = new Dictionary<int, List<Timer>>();
        }

        private int GetTimersCout(int instanceID)
        {
            var curOwner = timerDic.TryGetValue(instanceID, out var timers);
            if (timers == null) { return 0; }
            return timers.Count;
        }

        private int GetAllTimersCout()
        {
            var result = 0;
            foreach (var item in timerDic)
            {
                result += item.Value.Count;
            }
            return result;
        }

        public override void Tick()
        {
            base.Tick();
            foreach (var timerList in timerDic)
            {
                foreach (var item in timerList.Value)
                {
                    item.Tick();
                }
                timerList.Value.RemoveAll(t => t.isDone);
            }
            Debug.Log($"正在计时的计时器个数:{GetAllTimersCout()}");
        }

        public void RegisterTimer(Timer timer)
        {
            if (timerDic.TryGetValue(timer.owner, out var timers))
            {
                timers.Add(timer);
            }
            else
            {
                this.timerDic.Add(timer.owner, new List<Timer>() { timer });
            }
        }

        public void UnregisterTimer(Timer timer)
        {
            if (timerDic.TryGetValue(timer.owner, out var timers))
            {
                if (timers.Contains(timer))
                {
                    timers.Remove(timer);
                }
            }
        }

        public void UnregisterTimer(int instanceID, string timerName)
        {
            if (timerDic.TryGetValue(instanceID, out var timers))
            {
                var curTimer = timers.Find(t => t.timerName == timerName);
                if (curTimer != null)
                {
                    timers.Remove(curTimer);
                }
            }
        }

        public void UnregisterTimer(int instanceID, ETimerType timerType)
        {
            if (timerDic.TryGetValue(instanceID, out var timers))
            {
                foreach (var item in timers)
                {
                    if (item.timerType == timerType)
                    {
                        timers.Remove(item);
                    }
                }
            }
        }
    }
}
