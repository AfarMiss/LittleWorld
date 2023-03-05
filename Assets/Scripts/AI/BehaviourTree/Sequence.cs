using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Sequence : Node
    {
        public Sequence() { }
        public Sequence(string name) : base(name)
        {

        }

        public override void AddChild(Node n)
        {
            base.AddChild(n);
            if (currentChildIndex == -1)
            {
                currentChildIndex = 0;
            }
        }

        public override Status Process()
        {
            if (children.Count == 0)
            {
                return Status.FAILURE;
            }
            Status childStatus = children[currentChildIndex].Process();
            if (childStatus == Status.RUNNING || childStatus == Status.FAILURE)
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
                return Status.SUCCESS;
            }
            else
            {
                return Status.RUNNING;
            }
        }
    }
}
