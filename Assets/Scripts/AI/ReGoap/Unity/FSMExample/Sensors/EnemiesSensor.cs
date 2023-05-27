using System.Collections.Generic;
using ReGoap.Core;
using ReGoap.Unity.FSMExample.OtherScripts;
using UnityEngine;

namespace ReGoap.Unity.FSMExample.Sensors
{
    public class EnemiesSensor : ReGoapSensor<string, object>
    {
        Enemy curEnemy;
        public override void Init(IReGoapMemory<string, object> memory)
        {
            base.Init(memory);
            var state = memory.GetWorldState();
            state.Set("objective", curEnemy=FindObjectOfType<Enemy>());
        }

        public override void UpdateSensor()
        {
            if (curEnemy != null && curEnemy.isAlive) return;
            var state = memory.GetWorldState();
            state.Set("objective", curEnemy = FindObjectOfType<Enemy>());
        }
    }
}