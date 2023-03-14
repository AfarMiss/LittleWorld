using Sort;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// priority-selector，带权重的选择器
    /// 选择规则
    /// 当有更高优先级的选择子节点的触发条件被满足时，会打断当前子节点的运行，立刻跳转到高优先级子节点的运行
    /// 同优先级的多个子节点触发节点被满足时，会等待当前运行子节点运行结束
    /// </summary>
    public class PSelector : Node
    {
        public bool dynamic = false;
        public PSelector(string name, int priority, bool dynamic = false) : base(name, priority)
        {
            this.dynamic = dynamic;
        }

        public override Status Process()
        {
            QuickSort.Sort(children.ToArray(), 0, children.Count - 1);
            return base.Process();
        }
    }
}
