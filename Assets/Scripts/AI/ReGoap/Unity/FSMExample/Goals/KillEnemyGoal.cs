using ReGoap.Core;
using UnityEngine;

namespace ReGoap.Unity.FSMExample.Goals
{
    public class KillEnemyGoal : ReGoapGoal<string, object>
    {
        public Transform enemyTransform;

        protected override void Awake()
        {
            base.Awake();
            enemyTransform = GameObject.FindObjectOfType<Enemy>()?.transform;
            goal.Set("enemy" + enemyTransform.GetInstanceID() + "isDead", true);
        }

        public override string ToString()
        {
            return string.Format("GoapGoal('{0}', '{1}')", Name, enemyTransform.GetInstanceID());
        }
    }
}

