using LittleWorld.Item;
using LittleWorld.Jobs;
using System.Collections.Generic;

namespace LittleWorld
{
    public class WorkTracer
    {
        public static int workID = 0;
        public Queue<Work> workQueue;
        public WorkTracer(Animal pawn)
        {
            this.animal = pawn;
            workQueue = new Queue<Work>();
        }
        public WorkStatus CurStatus = WorkStatus.NoWork;
        public int curFinishedAmount;
        public int workTotalAmount;

        protected virtual void OnNoWork()
        {

        }

        public enum WorkStatus
        {
            Working,
            NoWork,
        }

        public Animal animal;
        private Work curWork;
        public AI.Node.Status curTreeStatus;

        public bool AddWork(Work singleWork)
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

        private bool AddWorkUnforced(Work singleWork)
        {
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool AddWorkForce(Work singleWork)
        {
            curWork?.OnAbort();
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool ClearAndAddWork(Work singleWork)
        {
            return true;
        }

        public void Tick()
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
            if (status != AI.Node.Status.RUNNING)
            {
                curWork = null;
            }
        }
    }
}
