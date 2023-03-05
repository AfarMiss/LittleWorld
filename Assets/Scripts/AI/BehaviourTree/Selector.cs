using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Selector : Node
    {
        public Selector() { }
        public Selector(string name) : base(name) { }

        public override Status Process()
        {
            Status childStatus = children[currentChildIndex].Process();

            switch (childStatus)
            {
                case Status.SUCCESS:
                    {
                        currentChildIndex = 0;
                        return Status.SUCCESS;
                    }
                case Status.RUNNING:
                    return Status.RUNNING;
                case Status.FAILURE:
                    currentChildIndex++;
                    if (currentChildIndex >= children.Count)
                    {
                        currentChildIndex = 0;
                        return Status.FAILURE;
                    }
                    else
                    {
                        return Status.RUNNING;
                    }
                default:
                    return Status.FAILURE;
            }
        }
    }
}
