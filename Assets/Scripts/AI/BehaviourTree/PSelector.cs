﻿using LittleWorld.Extension;
using Sort;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// 元素变动，优先级变动时
        /// </summary>
        private bool isDirty = true;
        public bool dynamic = false;
        public PSelector(string name, bool dynamic = false) : base(name)
        {
            this.dynamic = dynamic;
        }

        public void SetDirty()
        {
            isDirty = true;
        }

        public override Status Process()
        {
            if (isDirty)
            {
                //上一次执行的节点当前的优先级
                var lastPriority = children[currentChildIndex].Priority;
                var lastNode = children[currentChildIndex];
                if (children.Contains(lastNode))
                {
                    //重新排序
                    children = children.OrderByDescending(x => x.Priority).ToList();
                    if (currentChildIndex == -1 || (children.ValidIndex(currentChildIndex) && lastPriority < children[0].Priority))
                    {
                        currentChildIndex = 0;
                    }
                    //不变
                    else
                    {

                        currentChildIndex = children.IndexOf(lastNode);
                    }
                    isDirty = false;
                }
                else
                {
                    //重新排序
                    children = children.OrderByDescending(x => x.Priority).ToList();
                    currentChildIndex = 0;
                }
            }

            var childState = children[currentChildIndex].Process();
            switch (childState)
            {
                case Status.Success:
                    return Status.Success;
                case Status.Running:
                    return Status.Running;
                case Status.Failure:
                    if (children.Count > currentChildIndex + 1)
                    {
                        currentChildIndex++;
                        return Status.Running;
                    }
                    else
                    {
                        return Status.Failure;
                    }
                default:
                    return Status.Failure;
            }
        }
    }
}
