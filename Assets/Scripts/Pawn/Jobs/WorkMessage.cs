﻿using LittleWorld.Item;
using LittleWorld.Jobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Message
{
    public class WorkMessage
    {
        public float workPercent;
        public Humanbeing worker;
        public Vector2Int workPos;
        public int workID;
        public bool showPercent = true;

        public WorkMessage(WorkBT work, float workPercent, Humanbeing worker, Vector2Int workPos, bool showPercent = true)
        {
            this.workPercent = workPercent;
            this.worker = worker;
            this.showPercent = showPercent;
            this.workPos = workPos;
            this.workID = work.workID;
        }
    }

    public class WorkAbortMessage
    {
        public WorkBT work;

        public WorkAbortMessage(WorkBT work)
        {
            this.work = work;
        }
    }
}
