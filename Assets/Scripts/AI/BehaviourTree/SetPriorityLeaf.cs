using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class SetPriorityLeaf : Leaf
    {
        private int targetPriority;
        private Node targetNode;
        public override Status Process()
        {
            targetNode.Priority = targetPriority;
            return Status.Success;
        }

        public SetPriorityLeaf() { }

        public SetPriorityLeaf(Node targetNode, int targetPriority)
        {
            this.targetNode = targetNode;
            this.targetPriority = targetPriority;
        }
    }
}
