using ReGoap.Core;
using ReGoap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackAction : ReGoapAction<string, object>
{
    private Enemy enemy;
    public override ReGoapState<string, object> GetPreconditions(GoapActionStackData<string, object> stackData)
    {
        preconditions.Clear();
        if (settings.TryGetValue("enemy", out var enemy))
        {
            preconditions.Set("isAtTransform", enemy);
        }
        return preconditions;
    }

    public override void Run(IReGoapAction<string, object> previous, IReGoapAction<string, object> next, ReGoapState<string, object> settings, ReGoapState<string, object> goalState, System.Action<IReGoapAction<string, object>> done, System.Action<IReGoapAction<string, object>> fail)
    {
        base.Run(previous, next, settings, goalState, done, fail);

        if (settings.TryGetValue("enemy", out var enemy))
        {
            this.enemy = enemy as Enemy;
            Attack(this.enemy);
        }
    }

    public void Attack(Enemy enemy)
    {
        enemy.curHealth--;
        Debug.LogWarning($"{enemy} ’µΩ…À∫¶!");
    }

    public override ReGoapState<string, object> GetEffects(GoapActionStackData<string, object> stackData)
    {
        if (settings.TryGetValue("enemy", out var enemy))
        {
            this.enemy = enemy as Enemy;
            effects.Set("attack", true);
            if (!this.enemy.isAlive)
            {
                effects.Set($"enemy{this.enemy.GetInstanceID()}IsDead", true);
            }
        }

        return base.GetEffects(stackData);
    }
}
