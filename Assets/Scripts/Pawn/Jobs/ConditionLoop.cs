using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class ConditionLoop : Node
    {
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
                    Status childStatus = children[currentChild].Process();
                    if (childStatus == Status.RUNNING || childStatus == Status.FAILURE)
                    {
                        return childStatus;
                    }
                    else
                    {
                        currentChild++;
                    }

                    if (currentChild >= children.Count)
                    {
                        currentChild = 0;
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
