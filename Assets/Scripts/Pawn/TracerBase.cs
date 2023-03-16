using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld
{
    public abstract class TracerBase
    {
        protected bool enable = true;
        public virtual void OnDisable()
        {
            enable = false;
        }

        public virtual void OnEnable()
        {
            enable = true;
        }

        public abstract void Tick();
    }
}
