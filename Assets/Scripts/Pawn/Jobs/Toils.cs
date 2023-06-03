using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AI.MoveLeaf;
using static UnityEngine.Rendering.DebugUI;

namespace LittleWorld.Jobs
{
    public class SleepWork : IToil
    {
        public Animal animal;
        public Vector2Int target;
        public string toilName => $"正在睡眠";

        public SleepWork(Animal animal, Vector2Int target)
        {
            this.animal = animal;
            this.target = target;
        }

        public bool isDone => !animal.isSleeping;

        public void ToilStart()
        {
            animal.Sleep();
        }

        public void ToilTick()
        {
        }

        public void ToilCancel()
        {
            animal.WakeUp();
        }
    }

    public class DrinkWork : IToil
    {
        public Animal animal;
        public IDrinkable drinkable;
        public string toilName => $"正在喝{drinkable.itemName}";

        public DrinkWork(Animal animal, IDrinkable drinkable)
        {
            this.animal = animal;
            this.drinkable = drinkable;
        }

        public bool isDone => !animal.isDrinking;

        public void ToilStart()
        {
            animal.Drink(drinkable);
        }

        public void ToilCancel()
        {
            animal.UnDrink();
        }

        public void ToilTick()
        {
        }
    }

    public class EatWork : IToil
    {
        public Animal animal;
        public IEatable eatable;
        public string toilName => $"正在吃{eatable.itemName}";

        public EatWork(Animal animal, IEatable eatable)
        {
            this.animal = animal;
            this.eatable = eatable;
        }

        public bool isDone => !animal.isEating;

        public void ToilStart()
        {
            animal.Eat(eatable);
        }

        public void ToilTick()
        {
        }

        public void ToilCancel()
        {
            animal.UnEat();
        }
    }

    public class AttackWork : IToil
    {
        public Animal animal;
        public WorldObject target;
        public string toilName => $"正在攻击{target.ItemName}";

        public AttackWork(Animal animal, WorldObject wo)
        {
            this.animal = animal;
            this.target = wo;
        }

        public bool isDone
        {
            get
            {
                if (target is Animal animal)
                {
                    return animal.IsDead;
                }
                return target.isDestroyed;
            }
        }

        public void ToilStart()
        {
            animal.Attack(target);
        }

        public void ToilTick()
        {
        }

        public void ToilCancel()
        {
            animal.CancelAttack();
        }
    }
}
