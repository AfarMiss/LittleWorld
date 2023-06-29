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

        public bool canStart => true;

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

        public void ToilOnDone()
        {
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

        public bool canStart => true;

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

        public void ToilOnDone()
        {
        }
    }

    public class EatWork : IToil
    {
        public Animal animal;
        public IEatable eatable;
        public string toilName => $"正在吃{eatable.itemName}";
        public bool canStart => true;

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

        public void ToilOnDone()
        {
        }
    }

    public class AttackWork : IToil
    {
        public Animal animal;
        public WorldObject target;
        public string toilName => $"正在攻击{target.ItemName}";
        public bool canStart => true;

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

        public void ToilOnDone()
        {
        }
    }

    /// <summary>
    /// 复合工作，某动物将某物从某地搬向另一地
    /// </summary>
    public class CarryVariousWork : IToil
    {
        public Animal animal;
        public Vector2Int startPoint;
        public Vector2Int destination;
        public WorldObject[] carriedItem;

        public CarryVariousWork(Animal animal, Vector2Int startPoint, Vector2Int destination, WorldObject[] carriedItem)
        {
            this.animal = animal;
            this.startPoint = startPoint;
            this.destination = destination;
            this.carriedItem = carriedItem;
        }

        public string toilName => $"正在搬运";
        public bool canStart => true;

        public bool isDone
        {
            get
            {
                return animal.GridPos == destination;
            }
        }

        public void ToilStart()
        {
            //animal.Attack(target);
            animal.GoToLocToil(startPoint).PickUp(carriedItem, startPoint).GoToLocToil(destination);
        }

        public void ToilTick()
        {
        }

        public void ToilCancel()
        {
            (animal as Humanbeing).Dropdown(carriedItem);
        }

        public void ToilOnDone()
        {
            (animal as Humanbeing).Dropdown(carriedItem);
        }
    }

    public class PickUpToil : IToil
    {
        private Animal animal;
        private WorldObject[] carryItems;
        private Vector2Int startPoint;

        public PickUpToil(Animal animal, WorldObject[] carryItems, Vector2Int startPoint)
        {
            this.animal = animal;
            this.carryItems = carryItems;
            this.startPoint = startPoint;
        }

        public bool isDone
        {
            get
            {
                foreach (var item in carryItems)
                {
                    if (item.carriedParent != null)
                    {
                        continue;
                    }
                    return false;
                }
                return true;
            }
        }

        public string toilName => "搬起物品";

        public bool canStart => true;

        public void ToilCancel()
        {
        }

        public void ToilOnDone()
        {
        }

        public void ToilStart()
        {
            animal.Carry(carryItems, startPoint);
        }

        public void ToilTick()
        {
        }
    }

    /// <summary>
    /// 复合工作，某动物将某物从某地搬向另一地
    /// </summary>
    public class CarrySingleTypeWork : IToil
    {
        public Animal animal;
        public Vector2Int startPoint;
        public Vector2Int destination;
        public int itemCode;
        public int amount;

        public CarrySingleTypeWork(Animal animal, Vector2Int startPoint, Vector2Int destination, int itemCode, int amount)
        {
            this.animal = animal;
            this.startPoint = startPoint;
            this.destination = destination;
            this.itemCode = itemCode;
            this.amount = amount;
        }

        public string toilName => $"正在搬运";
        public bool canStart => true;

        public bool isDone
        {
            get
            {
                return animal.GridPos == destination;
            }
        }

        public void ToilStart()
        {
            animal.GoToLocToil(destination).Carry(itemCode, amount, startPoint).GoToLocToil(destination);
        }

        public void ToilTick()
        {
        }

        public void ToilCancel()
        {
            (animal as Humanbeing).DropdownAllInBag();
        }

        public void ToilOnDone()
        {
            (animal as Humanbeing).DropdownAllInBag();
        }
    }
}
