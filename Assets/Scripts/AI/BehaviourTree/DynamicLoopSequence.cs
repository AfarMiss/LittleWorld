using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 每当成功循环后，按照规则更新队列中的节点。
    /// </summary>
    public class DynamicLoopSequence : Node
    {
        public delegate List<Node> DynamicLoopSequenceUpdate();
        private DynamicLoopSequenceUpdate update;
        public DynamicLoopSequence(string nodeName, DynamicLoopSequenceUpdate update, NodeGraph graph = null) : base(nodeName, graph)
        {
            this.update = update;
        }

        public override Status Process()
        {
            if (children.Count == 0)
            {
                UpdateChildren();
            }
            Status childStatus = children[currentChildIndex].Process();
            //Debug.Log("childStatus:" + childStatus);
            if (childStatus == Status.Success)
            {
                currentChildIndex++;
                if (currentChildIndex >= children.Count)
                {
                    currentChildIndex = 0;
                    UpdateChildren();
                }
                return Status.Running;
            }
            return childStatus;
        }

        private void UpdateChildren()
        {
            this.RemoveAllChildren();
            this.AddChildren(update());
            //Debug.Log("更新子节点");
        }
    }
}
