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

        public override Status Process()
        {
            if (children.Count == 0)
            {
                return Status.FAILURE;
            }
            Status childStatus = children[currentChild].Process();
            if (childStatus == Status.RUNNING || childStatus == Status.FAILURE)
            {
                return childStatus;
            }
            else
            {
                currentChild++;
            }

            if (currentChild >= children.Count)
            {
                currentChild = 0;
                return Status.SUCCESS;
            }
            else
            {
                return Status.RUNNING;
            }
        }
    }
}
