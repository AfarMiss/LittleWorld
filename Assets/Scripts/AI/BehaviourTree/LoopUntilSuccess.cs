using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class LoopUntilSuccess : Node
    {
        public LoopUntilSuccess(string nodeName, NodeGraph graph = null) : base(nodeName, graph)
        {

        }

        public override Status Process()
        {
            if (children.Count == 0)
            {
                Debug.LogWarning("空循环");
                return Status.Failure;
            }
            Status childStatus = children[currentChildIndex].Process();
            if (childStatus == Status.Success)
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
                return Status.Running;
            }
        }
    }
}
