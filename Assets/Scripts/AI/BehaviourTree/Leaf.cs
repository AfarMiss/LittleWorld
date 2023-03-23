using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Leaf : Node
    {
        public delegate Status Tick();
        public Tick ProcessMethod;

        public override Status Process()
        {
            Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod();
            return Status.Failure;
        }

        public Leaf() { }

        public Leaf(string n, Tick pm)
        {
            name = n;
            ProcessMethod = pm;
        }
    }
}
