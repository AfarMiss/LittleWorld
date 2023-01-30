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

        private SingleWork curWork;

        public bool AddWork(SingleWork singleWork)
        {
            return true;
        }

        public bool ClearAndAddWork(SingleWork singleWork)
        {
            return false;
        }

        public void Tick()
        {
            switch (CurStatus)
            {
                case WorkStatus.Working:
                    break;
                case WorkStatus.NoWork:
                    break;
                default:
                    break;
            }
        }

        private void ProcessWorkPercent(PawnWorkTracer work)
        {
            if (curFinishedAmount >= workTotalAmount)
            {
                CurStatus = WorkStatus.NoWork;
            }
            if (curFinishedAmount < workTotalAmount)
            {
                curFinishedAmount++;
            }
        }
    }
}
