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
        public Vector2Int workPos;
        public bool showPercent = true;

        public WorkMessage(float workPercent, Humanbeing worker, Vector2Int workPos, bool showPercent = true)
        {
            this.workPercent = workPercent;
            this.worker = worker;
            this.showPercent = showPercent;
            this.workPos = workPos;
        }
    }
}
