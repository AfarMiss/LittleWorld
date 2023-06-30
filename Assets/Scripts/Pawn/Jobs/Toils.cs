using AI;
using LittleWorld.Item;
using LittleWorld.MapUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

    public class CarryToBuildingWork : IToil
    {
        private Animal animal;
        private Vector2Int startPoint;
        private Vector2Int destination;
        private WorldObject[] carriedItem;
        private Building building;

        private UnityAction _onDone;

        public CarryToBuildingWork(Animal animal, Vector2Int startPoint, Vector2Int destination, WorldObject[] carriedItem, Building building, UnityAction onDone)
        {
            this.animal = animal;
            this.startPoint = startPoint;
            this.destination = destination;
            this.carriedItem = carriedItem;
            this.building = building;

            this._onDone = onDone;
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
                building.AddBuildingRawMaterials(carriedItem);
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
            _onDone?.Invoke();
        }
    }


    /// <summary>
    /// 复合工作，某动物将某物从某地搬向另一地，最终放下
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

    public class Toil : IToil
    {
        private Func<string> _toilName;
        private Func<bool> _isDone;
        private Func<bool> _canStart;

        private UnityAction _OnStart;
        private UnityAction _Tick;
        private UnityAction _OnDone;
        private UnityAction _OnCancel;

        public Toil(Func<string> toilName, Func<bool> isDone, UnityAction onStart, UnityAction tick, UnityAction onDone, UnityAction onCancel, Func<bool> canStart)
        {
            _toilName = toilName;
            _isDone = isDone;
            _OnStart = onStart;
            _Tick = tick;
            _OnDone = onDone;
            _OnCancel = onCancel;
            _canStart = canStart;
        }

        //public bool isDone => _isDone?.Invoke();这样写不行，报“不能将可空bool赋值给bool”的错

        public bool isDone
        {
            get
            {
                if (_isDone != null)
                {
                    _isDone.Invoke();
                }
                return true;
            }
        }

        public string toilName => _toilName?.Invoke();

        public bool canStart
        {
            get
            {
                if (_canStart != null)
                {
                    _canStart.Invoke();
                }
                return true;
            }
        }

        public void OnCancel()
        {
            _OnCancel?.Invoke();
        }

        public void OnDone()
        {
            _OnDone?.Invoke();
        }

        public void OnStart()
        {
            _OnStart?.Invoke();
        }

        public void Tick()
        {
            _Tick?.Invoke();
        }
    }

    public class BuildingToil : IToil
    {
        private Animal _animal;
        private Building _building;

        public BuildingToil(Animal animal, Building building)
        {
            this._animal = animal;
        }

        public bool isDone
        {
            get
            {
                _building.curBuildingPoint == _building.maxBuildingPoint;
            }
        }

        public string toilName => "建造";

        public bool canStart => true;

        public void OnCancel()
        {
        }

        public void OnDone()
        {
            _building.Finish();
        }

        public void OnStart()
        {
        }

        public void Tick()
        {
        }
    }
}
