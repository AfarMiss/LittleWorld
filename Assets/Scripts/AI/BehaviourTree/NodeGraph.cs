using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 节点容器
    /// </summary>
    public class NodeGraph
    {
        public Blackboard blackboard;

        public NodeGraph(Blackboard blackboard)
        {
            this.blackboard = blackboard;
        }
    }
}
