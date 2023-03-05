﻿using System.Collections;
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
