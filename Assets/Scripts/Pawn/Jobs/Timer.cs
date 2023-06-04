using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class Timer
    {
        public int owner;
        public float duration;
        public bool isDone;
        public Action OnComplete;
        public Action OnUpdate;
        public Action OnStart;
        public ETimerType timerType;
        public string timerName;

        private float _startTime;
        private float _lastUpdateTime;
        private float _endTime;
        private bool _isPause;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="duration">持续时间，单位:s</param>
        /// <param name="onComplete"></param>
        /// <param name="onUpdate"></param>
        /// <param name="ownerId"></param>
        public Timer(string timerName, float duration, Action OnStart = null, Action onComplete = null, Action onUpdate = null, ETimerType timerType = ETimerType.trigger, int ownerId = -1)
        {
            this.owner = ownerId;
            this.duration = duration;
            OnComplete = onComplete;
            OnUpdate = onUpdate;
            this.OnStart = OnStart;
            _startTime = GetWorldTime();
            this._endTime = _startTime + duration;
            isDone = false;
            this.OnStart?.Invoke();
            this.timerType = timerType;
            this.timerName = timerName;
        }

        public void Dispose()
        {

        }

        public void Tick()
        {
            OnUpdate?.Invoke();
            _lastUpdateTime = GetWorldTime();
            if (_lastUpdateTime > GetFireTime())
            {
                OnComplete?.Invoke();
                isDone = true;
            }
        }

        private float GetWorldTime()
        {
            //return this.usesRealTime ? Time.realtimeSinceStartup : Time.time;
            return Time.time;
        }

        private float GetFireTime()
        {
            return this._startTime + this.duration;
        }

        private float GetTimeDelta()
        {
            return this.GetWorldTime() - this._lastUpdateTime;
        }
    }

    public enum ETimerType
    {
        /// <summary>
        /// 持续性计时，如果立刻要去做新的工作，则该计时器会被打断。
        /// </summary>
        Continous,
        /// <summary>
        /// 触发式计时，如果立刻要去做新的工作，该计时器继续计时，不会被打断。
        /// </summary>
        trigger,
    }
}
