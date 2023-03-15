using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Selector : Node
    {
        public Selector() { }
        public Selector(string name, NodeGraph graph = null) : base(name, graph) { }

        public override Status Process()
        {
            Status childStatus = children[currentChildIndex].Process();

            switch (childStatus)
            {
                case Status.Success:
                    {
                        currentChildIndex = 0;
                        return Status.Success;
                    }
                case Status.Running:
                    return Status.Running;
                case Status.Failure:
                    currentChildIndex++;
                    if (currentChildIndex >= children.Count)
                    {
                        currentChildIndex = 0;
                        return Status.Failure;
                    }
                    else
                    {
                        return Status.Running;
                    }
                default:
                    return Status.Failure;
            }
        }
    }
}
