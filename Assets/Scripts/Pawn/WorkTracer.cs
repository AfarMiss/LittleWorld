using LittleWorld.Item;
using LittleWorld.Jobs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public delegate bool ToilTick();
    public interface IToil
    {
        bool isDone { get; }
        string toilName { get; }
        bool canStart { get; }
        void Tick();
        void OnStart();
        void OnCancel();
        void OnDone();
    }

    public class WorkTracer : TracerBase
    {
        public static int workID = 0;
        public Queue<WorkBT> workQueue;
        public Queue<IToil> toils;
        public WorkStatus CurStatus = WorkStatus.NoWork;
        public int curFinishedAmount;
        public int workTotalAmount;
        public IToil curToil => _curToil;

        private IToil _curToil;

        public WorkTracer(Animal pawn)
        {
            this.animal = pawn;
            workQueue = new Queue<WorkBT>();
            toils = new Queue<IToil>();
        }


        protected virtual void OnNoWork()
        {
            
        }

        public enum WorkStatus
        {
            Working,
            NoWork,
        }

        public Animal animal;
        private WorkBT curWork;
        public AI.Node.Status curTreeStatus;

        public void TryClean()
        {
            if (!Current.IsAdditionalMode)
            {
                foreach (var item in toils)
                {
                    item.OnCancel();
                }
            }
            _curToil?.OnCancel();
            _curToil = null;
            toils.Clear();
        }

        public void AddToil(IToil toil)
        {
            if (toil.canStart)
            {
                toils.Enqueue(toil);
            }
        }

        public void StartToil()
        {
            _curToil = toils.Dequeue();
        }

        public bool AddWork(WorkBT singleWork)
        {
            if (Current.IsAdditionalMode)
            {
                return AddWorkUnforced(singleWork);
            }
            else
            {
                return AddWorkForce(singleWork);
            }
        }

        private bool AddWorkUnforced(WorkBT singleWork)
        {
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool AddWorkForce(WorkBT singleWork)
        {
            curWork?.OnAbort();
            curWork = null;
            workQueue.Clear();
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool ClearAndAddWork(WorkBT singleWork)
        {
            return true;
        }

        public override void OnDisable()
        {
            curWork?.OnAbort();
            base.OnDisable();
        }

        public override void Tick()
        {
            CheckOldWork();
            if (curToil == null)
            {
                toils.TryDequeue(out _curToil);
                if (curToil != null)
                {
                    curToil.OnStart();
                }
                return;
            }

            if (curToil.isDone)
            {
                curToil.OnDone();
                _curToil = null;
                return;
            }

            curToil.Tick();
        }


        /// <summary>
        /// 检查工作系统（旧
        /// </summary>
        public void CheckOldWork()
        {
            if (curWork == null)
            {
                if (workQueue.Count == 0)
                {
                    OnNoWork();
                    return;
                }
                else
                {
                    curWork = workQueue.Dequeue();
                }
            }
            var status = curWork.Tick();
            if (status != AI.Node.Status.Running)
            {
                if (status == AI.Node.Status.Failure)
                {
                    Debug.LogWarning($"{curWork.GetType()}_{curWork.workID}失败");
                }
                curWork = null;
            }
        }
    }
}
