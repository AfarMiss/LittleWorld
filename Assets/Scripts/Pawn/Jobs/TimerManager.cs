using System.Collections;
using System.Collections.Generic;
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
    }
}
