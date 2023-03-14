using LittleWorld.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 思考行为节点，目前的表现即是目标停顿在原地不动
    /// </summary>
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
                return Status.Success;
            }
            else
            {
                return Status.Running;
            }
        }
    }
}
