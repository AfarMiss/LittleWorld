using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 直到条件成立，返回成功
    /// </summary>
    public class LoopUnitlConditionSuccess : Node
    {
        /// <summary>
        /// 条件
        /// </summary>
        /// <returns></returns>
        public delegate bool Tick();
        private Tick check;

        public LoopUnitlConditionSuccess(string name, Tick check)
        {
            this.name = name;
            this.check = check;
        }

        public override Status Process()
        {

            if (check != null)
            {
                if (check())
                {
                    return Status.SUCCESS;
                }
                else
                {
                    Status childStatus = children[currentChildIndex].Process();
                    switch (childStatus)
                    {
                        case Status.SUCCESS:
                            currentChildIndex++;
                            if (currentChildIndex >= children.Count)
                            {
                                currentChildIndex = 0;
                            }
                            return Status.RUNNING;
                        case Status.RUNNING:
                            return Status.RUNNING;
                        case Status.FAILURE:
                            this.RunningReset();
                            Debug.LogWarning($"LoopUnitlConditionSuccess节点:{this.name}当前循环失败,重置!");
                            return Status.RUNNING;
                        default:
                            return Status.RUNNING;
                    }
                }
            }
            else
            {
                return Status.FAILURE;
            }
        }
    }
}
