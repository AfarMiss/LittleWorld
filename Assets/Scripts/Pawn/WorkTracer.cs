using LittleWorld.Item;
using LittleWorld.Jobs;
using System.Collections.Generic;

namespace LittleWorld
{
    public class WorkTracer
    {
        public static int workID = 0;
        public Queue<WorkBT> workQueue;
        public WorkTracer(Animal pawn)
        {
            this.animal = pawn;
            workQueue = new Queue<WorkBT>();
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
        private WorkBT curWork;
        public AI.Node.Status curTreeStatus;

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
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool ClearAndAddWork(WorkBT singleWork)
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
            if (status != AI.Node.Status.Running)
            {
                curWork = null;
            }
        }
    }
}
