using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Message
{
    public class WorkMessage
    {
        public float workPercent;
        public Humanbeing worker;

        public WorkMessage(float workPercent, Humanbeing worker)
        {
            this.workPercent = workPercent;
            this.worker = worker;
        }
    }
}
