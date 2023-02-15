using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class CheckLeaf : Node
    {
        public delegate bool Tick();
        private Tick check;
        private Action OnSuccess;
        private Action OnFail;

        public CheckLeaf(string name, Tick check, Action OnSuccess = null, Action OnFail = null)
        {
            this.name = name;
            this.check = check;
            this.OnSuccess = OnSuccess;
            this.OnFail = OnFail;
        }

        public override Status Process()
        {

            if (check != null)
            {
                if (check())
                {
                    OnSuccess?.Invoke();
                    return Status.SUCCESS;
                }
                else
                {
                    OnFail?.Invoke();
                    return Status.FAILURE;
                }

            }
            else
            {
                return Status.FAILURE;
            }


        }
    }
}
