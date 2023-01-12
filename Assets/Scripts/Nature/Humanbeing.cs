using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorldObject
{
    public class Humanbeing : Animal
    {
        private PawnWorkTracer pawnWorkTracer;
        public Humanbeing(Vector3Int gridPos) : base(gridPos)
        {
            this.gridPos = gridPos;
            ItemName = "人类";
            actionQueue = new Queue<HumanAction>();
            curInteractionItemID = -1;

            pawnWorkTracer = new PawnWorkTracer(this);
        }
        public Queue<HumanAction> actionQueue;
        public Coroutine curPickCoroutine;
        public int curInteractionItemID;
    }
}