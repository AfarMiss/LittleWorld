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
        public Timer(float duration, Action onComplete, Action onUpdate, int ownerId = -1)
        {
            this.owner = ownerId;
            this.duration = duration;
            OnComplete = onComplete;
            OnUpdate = onUpdate;
            _startTime = GetWorldTime();
            this._endTime = _startTime + duration;
            isDone = false;
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
}
