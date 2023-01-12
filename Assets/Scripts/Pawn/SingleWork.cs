using LittleWorldObject;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LittleWorld
{
    public class SingleWork
    {
        public string uniqueKey;
        public Action WhenReached => whenReached;
        public Vector3Int WorkPos => workPos;

        public int workTotalAmount;
        public int curFinishedAmount;
        public WorkStateEnum WorkState
        {
            get
            {
                return workState;
            }
            set
            {
                workState = value;
                switch (value)
                {
                    case WorkStateEnum.OnGoing:
                        EventCenter.Instance.Trigger(EventEnum.WORK_GOTO_WORK_POS.ToString(), this);
                        break;
                    case WorkStateEnum.Working:
                        EventCenter.Instance.Trigger(EventEnum.WORK_WORKING.ToString(), this);
                        break;
                    case WorkStateEnum.Suspend:
                        EventCenter.Instance.Trigger(EventEnum.WORK_SUSPEND.ToString(), this);
                        break;
                    case WorkStateEnum.Done:
                        EventCenter.Instance.Trigger(EventEnum.WORK_DONE.ToString(), this);
                        break;
                    default:
                        break;
                }
            }
        }

        public Humanbeing worker;

        private WorkStateEnum workState;
        private WorkTypeEnum workType;
        private Action whenReached;
        private Vector3Int workPos;

        public SingleWork(string uniqueKey, Humanbeing worker, WorkStateEnum workState, WorkTypeEnum workType, Action whenReached, Vector3Int workPos,
            int curFinishedAmount, int workTotalAmount
            )
        {
            this.worker = worker;
            this.WorkState = workState;
            this.workType = workType;
            this.whenReached = whenReached;
            this.workPos = workPos;
            this.uniqueKey = uniqueKey;
            this.curFinishedAmount = curFinishedAmount;
            this.workTotalAmount = workTotalAmount;
        }
    }
}
