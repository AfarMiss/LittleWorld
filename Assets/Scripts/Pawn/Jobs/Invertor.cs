using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Inverter : Node
    {
        public Inverter(string n)
        {
            name = n;
        }

        public override Status Process()
        {
            var s = children[currentChildIndex].Process();
            switch (s)
            {
                case Status.Success:
                    return Status.Failure;
                case Status.Running:
                    return Status.Running;
                case Status.Failure:
                    return Status.Success;
                default:
                    return Status.Failure;
            }

        }
    }
}
