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

        public void OnStart()
        {
            animal.Sleep();
        }

        public void Tick()
        {
        }

        public void OnCancel()
        {
            animal.WakeUp();
        }

        public void OnDone()
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

        public void OnStart()
        {
            animal.Drink(drinkable);
        }

        public void OnCancel()
        {
            animal.UnDrink();
        }

        public void Tick()
        {
        }

        public void OnDone()
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

        public void OnStart()
        {
            animal.Eat(eatable);
        }

        public void Tick()
        {
        }

        public void OnCancel()
        {
            animal.UnEat();
        }

        public void OnDone()
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

        public void OnStart()
        {
            animal.Attack(target);
        }

        public void Tick()
        {
        }

        public void OnCancel()
        {
            animal.CancelAttack();
        }

        public void OnDone()
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

        private bool _isDone;

        public bool isDone => _isDone;

        public void OnStart()
        {
            animal.GoToLocToil(startPoint, OnToilEnd: () =>
            {
                animal.Carry(carriedItem, startPoint);
            }).GoToLocToil(destination, OnToilEnd: () =>
            {
                animal.DropdownAllInBag();
            });
            //目前还有一种写法：animal.GoToLocToil(startPoint).PickUp(carriedItem, startPoint).GoToLocToil(destination).DropDownAll();
            //但是我认为捡起和放下是瞬时动作，应该和“去往某地”这样的动作做区分。
            _isDone = true;
        }

        public void Tick()
        {
        }

        public void OnCancel()
        {
        }

        public void OnDone()
        {
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

        public void OnCancel()
        {
        }

        public void OnDone()
        {
        }

        public void OnStart()
        {
            animal.Carry(carryItems, startPoint);
        }

        public void Tick()
        {
        }
    }

    public class DropDownAllToil : IToil
    {
        private Animal animal;

        public DropDownAllToil(Animal animal)
        {
            this.animal = animal;
        }

        public bool isDone
        {
            get
            {
                return animal.bag.Count == 0;
            }
        }

        public string toilName => "放下物品";

        public bool canStart => true;

        public void OnCancel()
        {
        }

        public void OnDone()
        {
        }

        public void OnStart()
        {
            animal.DropdownAllInBag();
        }

        public void Tick()
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

        public void OnStart()
        {
            animal.GoToLocToil(destination).Carry(itemCode, amount, startPoint).GoToLocToil(destination);
        }

        public void Tick()
        {
        }

        public void OnCancel()
        {
            (animal as Humanbeing).DropdownAllInBag();
        }

        public void OnDone()
        {
            (animal as Humanbeing).DropdownAllInBag();
        }
    }
}
