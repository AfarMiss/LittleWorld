﻿using LittleWorld.Item;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public class PawnWorkTracer
    {
        public static int workID;
        public PawnWorkTracer(Humanbeing pawn)
        {
            this.pawn = pawn;
            workQueue = new Queue<SingleWork>();

            EventCenter.Instance.Register<int>(EventEnum.REACH_WORK_POINT.ToString(), OnReachWorkPoint);
        }

        private void OnReachWorkPoint(int instanceID)
        {
            if (pawn.instanceID != instanceID)
            {
                return;
            }
            if (curWork == null)
            {
                Debug.LogError("worker has no work");
                return;
            }

            curWork.WorkState = WorkStateEnum.Working;
            if (curWork.WhenReached != null)
            {
                curWork.WhenReached();
            }
        }

        private Humanbeing pawn;
        public Queue<SingleWork> WorkQueue => workQueue;
        private Queue<SingleWork> workQueue;

        private SingleWork curWork;

        public bool AddWork(SingleWork singleWork)
        {
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool ClearAndAddWork(SingleWork singleWork)
        {
            CancelAllWork();
            workQueue.Enqueue(singleWork);
            return true;
        }

        public bool CancelAllWork()
        {
            WorkQueue.Clear();
            if (curWork != null)
            {
                curWork.WorkState = WorkStateEnum.FORCE_ABORT;
            }
            return true;
        }

        public bool GetWorkAndStart()
        {
            if (workQueue == null || workQueue.Count == 0)
            {
                return false;
            }
            curWork = workQueue.Dequeue();

            curWork.WorkState = WorkStateEnum.OnGoing;
            return true;
        }

        public void Tick()
        {
            if (curWork == null || curWork.WorkState == WorkStateEnum.Done)
            {
                GetWorkAndStart();
                return;
            }
            if (curWork.WorkState == WorkStateEnum.Working)
            {
                ProcessWorkPercent(curWork);
            }
            if (curWork.WorkState == WorkStateEnum.OnGoing)
            {

            }
            if (curWork.WorkState == WorkStateEnum.FORCE_ABORT)
            {
                curWork = null;
            }
        }

        private void ProcessWorkPercent(SingleWork work)
        {
            if (work.workTotalAmount <= 0 || work.curFinishedAmount >= work.workTotalAmount)
            {
                work.WorkState = WorkStateEnum.Done;
            }
            if (work.curFinishedAmount < work.workTotalAmount)
            {
                work.curFinishedAmount++;
                EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), work);
            }
        }
    }
}
