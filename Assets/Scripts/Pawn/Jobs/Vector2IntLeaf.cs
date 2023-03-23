using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AI
{
    public class Vector2IntLeaf : Node
    {
        public delegate Status Tick(out Vector2Int result);
        public Tick ProcessMethod;
        public Vector2Int result;

        public override Status Process()
        {
            Debug.Log("[currentChild]:" + name);
            if (ProcessMethod != null)
                return ProcessMethod(out result);
            return Status.Failure;
        }

        public Vector2IntLeaf() { }

        public Vector2IntLeaf(string n, Tick pm)
        {
            name = n;
            ProcessMethod = pm;
        }
    }
}
