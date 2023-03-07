using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class LoopUntilSuccess : Node
    {
        public LoopUntilSuccess(string nodeName) : base(nodeName)
        {

        }

        public override Status Process()
        {
            if (children.Count == 0)
            {
                Debug.LogWarning("空循环");
                return Status.FAILURE;
            }
            Status childStatus = children[currentChildIndex].Process();
            if (childStatus == Status.SUCCESS)
            {
                currentChildIndex++;
                if (currentChildIndex >= children.Count)
                {
                    currentChildIndex = 0;
                }
                return childStatus;
            }
            else
            {
                return Status.RUNNING;
            }
        }
    }
}
