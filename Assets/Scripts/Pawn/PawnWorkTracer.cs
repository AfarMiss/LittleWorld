using AStarUtility;
using LittleWorld.Item;
using LittleWorld.Jobs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class PawnWorkTracer
    {
        public static int workID = 0;
        public Queue<Work> workQueue;
        public PawnWorkTracer(Humanbeing pawn)
        {
            this.pawn = pawn;
            workQueue = new Queue<Work>();
        }
        public WorkStatus CurStatus = WorkStatus.NoWork;
        public int curFinishedAmount;
        public int workTotalAmount;

        public enum WorkStatus
        {
            Working,
            NoWork,
        }

        public Humanbeing pawn;

        private Work curWork;
        public BehaviourTreeUtility.Node.Status curTreeStatus;

        public bool AddWork(Work singleWork)
        {
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool ClearAndAddWork(SingleWork singleWork)
        {
            return false;
        }

        public void Tick()
        {
            if (curWork == null)
            {
                if (workQueue.Count == 0)
                {
                    return;
                }
                else
                {
                    curWork = workQueue.Dequeue();
                }
            }
            var status = curWork.Tick();
            if (status == BehaviourTreeUtility.Node.Status.SUCCESS)
            {
                curWork = null;
            }
        }

        private void ProcessWorkPercent(PawnWorkTracer work)
        {
            if (curFinishedAmount >= workTotalAmount)
            {
                CurStatus = WorkStatus.NoWork;
            }
            else
            {
                CurStatus = WorkStatus.Working;
                curFinishedAmount++;
            }
        }
    }
}
