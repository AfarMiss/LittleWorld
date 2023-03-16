using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class LoopUntilFailure : Node
    {
        public LoopUntilFailure() { }
        public LoopUntilFailure(string name, NodeGraph graph = null) : base(name, graph)
        {

        }

        public override Status Process()
        {
            if (children.Count == 0)
            {
                return Status.Failure;
            }
            Status childStatus = children[currentChildIndex].Process();
            if (childStatus == Status.Running || childStatus == Status.Failure)
            {
                return childStatus;
            }
            else
            {
                currentChildIndex++;
            }

            if (currentChildIndex >= children.Count)
            {
                currentChildIndex = 0;
            }
            return Status.Running;
        }
    }
}
