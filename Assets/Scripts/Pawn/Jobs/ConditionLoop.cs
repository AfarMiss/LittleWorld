using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    /// <summary>
    /// 直到条件成立，返回成功
    /// </summary>
    public class ConditionLoop : Node
    {
        /// <summary>
        /// 条件
        /// </summary>
        /// <returns></returns>
        public delegate bool Tick();
        private Tick check;

        public ConditionLoop(string name, Tick check)
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
                    if (childStatus == Status.RUNNING || childStatus == Status.FAILURE)
                    {
                        return childStatus;
                    }
                    else
                    {
                        currentChildIndex++;
                    }

                    if (currentChildIndex >= children.Count)
                    {
                        currentChildIndex = 0;
                    }

                    return Status.RUNNING;
                }
            }
            else
            {
                return Status.FAILURE;
            }


        }
    }
}
