using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class ThinkLeaf : Node
    {
        private float thinkingMaxTime;
        private float thinkingMinTime;
        private float? curThinkingTime;

        public ThinkLeaf(Animal animal, float thinkingMinTime = 0, float thinkingMaxTime = 5)
        {
            this.thinkingMaxTime = thinkingMaxTime;
            this.thinkingMinTime = thinkingMinTime;
            if (thinkingMaxTime < thinkingMinTime)
            {
                thinkingMaxTime = thinkingMinTime;
            }
            if (curThinkingTime == null)
            {
                curThinkingTime = Random.Range(thinkingMinTime, thinkingMaxTime);
            }
            Debug.Log(animal + " Thinking for " + curThinkingTime + " s");
        }

        public override Status Process()
        {
            curThinkingTime -= GameSetting.TickTime;
            if (curThinkingTime <= 0)
            {
                return Status.SUCCESS;
            }
            else
            {
                return Status.RUNNING;
            }
        }
    }
}
