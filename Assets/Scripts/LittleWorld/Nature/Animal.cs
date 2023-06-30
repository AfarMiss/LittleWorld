using LittleWorld.Item;
using LittleWorld.Jobs;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Events;
using static AI.MoveLeaf;
using static LittleWorld.HealthTracer;
using static LittleWorld.Item.Bullet;

namespace LittleWorld.Item
{
    public class Animal : Living
    {
        public List<WorldObject> bag = new List<WorldObject>();
        public GearTracer gearTracer;
        protected PathTracer pathTracer;
        protected AnimalInfo animalInfo;
        protected WorkTracer workTracer;

        public PathTracerRender RenderTracer;
        public string curToilName => workTracer.curToil != null ? workTracer.curToil.toilName : "";
        public ItemRender ItemRender => SceneObjectManager.Instance.GetRenderer(instanceID);
        /// <summary>
        /// 是否处于被征召状态
        /// </summary>
        protected bool isDrafted = false;
        public Face FaceTo => pathTracer.animalFace;
        public float MoveSpeed => animalInfo.moveSpeed;
        public bool IsMoving => pathTracer.IsMoving;
        public Vector2Int? CurDestination => pathTracer.CurDestination;

        public float CurHunger => healthTracer.curHealth;
        public float HungerPercent => healthTracer.curHunger / healthTracer.maxHunger;
        public float SleepPercent => healthTracer.curSleep / healthTracer.maxSleep;
        public float ThirstyPercent => healthTracer.curThirsty / healthTracer.maxThirsty;

        public PathTracer PathTracer { get => pathTracer; }
        private bool deadFlag => this.healthTracer != null && this.healthTracer.deadFlag;

        /// <summary>
        /// 注册被伤害时事件
        /// </summary>
        public Action OnBeHurt;
        public bool isEating => healthTracer.isEating;
        public bool isDrinking => healthTracer.isDrinking;

        public Animal(int itemCode, Age age, Vector2Int gridPos) : base(itemCode, gridPos)
        {
            animalInfo = ObjectConfig.ObjectInfoDic[itemCode] as AnimalInfo;
            workTracer = new NonAggressiveWorkTracer(this);
            healthTracer = new HealthTracer(100, 1f, 1f, 1f, age, this);
            pathTracer = new PathTracer(this);
            gearTracer = new GearTracer(this);

            this.workTracer.OnEnable();
            this.healthTracer.OnEnable();
            this.pathTracer.OnEnable();
        }

        public override void OnBeEatenCompletely()
        {
            base.OnBeEatenCompletely();
            ItemRender.OnDispose();
        }

        public Animal SleepToil(Vector2Int pos)
        {
            workTracer.AddToil(new SleepWork(this, pos));
            return this;
        }

        public void TryCleanWork()
        {
            this.workTracer.TryClean();
        }

        public Animal EatToil(IEatable eatable)
        {
            workTracer.AddToil(new EatWork(this, eatable));
            return this;
        }

        public Animal AddBuildingToil(Building building)
        {
            foreach (var item in building.GetRawMaterialNeedYet())
            {
                var startPoint = SceneObjectManager.Instance.SearchForRawMaterials(item.Key);
                var carriedItems = new List<WorldObject>();
                foreach (var wo in WorldUtility.GetObjectsAtCell(startPoint))
                {
                    if (wo.itemCode == item.Key)
                    {
                        carriedItems.Add(wo as WorldObject);
                        workTracer.AddToil(new CarryVariousWork(this, startPoint, building.GridPos, carriedItems.ToArray()));
                    }
                }

            }
            return this;
        }

        public Animal SearchForRawMaterials(int objectId)
        {
            SceneObjectManager.Instance.SearchForRawMaterials(objectId);
            return this;
        }

        public Animal DrinkToil(IDrinkable drinkable)
        {
            workTracer.AddToil(new DrinkWork(this, drinkable));
            return this;
        }

        public Animal Toil(Func<string> toilName, Func<bool> isDone, UnityAction onStart, UnityAction tick, UnityAction onDone, UnityAction onCancel, Func<bool> canStart)
        {
            workTracer.AddToil(new Toil(toilName, isDone, onStart, tick, onDone, onCancel, canStart));
            return this;
        }

        public void Sleep()
        {
            this.healthTracer.isSleeping = true;
        }

        public void WakeUp()
        {
            healthTracer.isSleeping = false;
        }

        public void Eat(IEatable eatable)
        {
            healthTracer.Eat(eatable);
        }

        public void Drink(IDrinkable drinkable)
        {
            healthTracer.Drink(drinkable);
        }

        public void UnEat()
        {
            TimerManager.Instance.UnregisterTimer(this.instanceID, TimerName.EAT);
        }

        public void UnDrink()
        {
            TimerManager.Instance.UnregisterTimer(this.instanceID, TimerName.DRINK);
        }

        public override Sprite GetCurrentSprite()
        {
            return animalInfo.ItemSprites[0];
        }

        public virtual void Die()
        {
            this.pathTracer.OnDisable();
            this.workTracer.OnDisable();
            this.healthTracer.OnDisable();
            this.ItemRender.OnDie();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.Die();
            this.pathTracer = null;
            this.workTracer = null;
            this.healthTracer = null;
        }

        public void StopAllAction()
        {
            if (this is Humanbeing humanbeing)
            {
                humanbeing.gearTracer.curWeapon?.StopFire();
            }
        }

        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="damageSource">伤害来源</param>
        public virtual void BeHurt(float damage, WorldObject damageSource)
        {
            healthTracer.GetDamage(damage);
            OnBeHurt?.Invoke();
            EventCenter.Instance.Trigger(EventName.LIVING_BE_HURT, new DamageInfo
            {
                target = this,
                hunter = damageSource as Humanbeing,
            });
        }

        public Sprite GetFaceSprite()
        {
            return GetSprite(FaceTo);
        }

        public void ShowPath()
        {
            pathTracer.ShowPath();
        }

        public void AddAttackToil(WorldObject target)
        {
            workTracer.AddToil(new AttackWork(this, target));
        }

        public void Attack(WorldObject animal)
        {
            gearTracer.Attack(animal);
        }

        public void CancelAttack()
        {
            gearTracer.CancelAttack();
        }

        public void HidePath()
        {
            pathTracer.HidePath();
        }

        protected virtual Sprite GetSprite(Face face)
        {
            switch (face)
            {
                case Face.Up:
                    return animalInfo.ItemSprites[1];
                case Face.Down:
                    return animalInfo.ItemSprites[0];
                case Face.Left:
                    return animalInfo.ItemSprites[2];
                case Face.Right:
                    return animalInfo.ItemSprites[2];
                default:
                    return animalInfo.ItemSprites[1];
            }
        }

        public bool CarrySingle(WorldObject wo, Vector2Int destination)
        {
            Current.CurMap.GetGrid(destination, out var result);
            if (result.PickUp(wo, this))
            {
                bag.Add(wo);
                return true;
            }
            return false;
        }

        public bool CarrySingle(int itemCode, Vector2Int destination, out WorldObject wo)
        {
            Current.CurMap.GetGrid(destination, out var result);
            if (result.PickUp(itemCode, this, out wo))
            {
                bag.Add(wo);
                return true;
            }
            return false;
        }

        public Animal Carry(WorldObject[] wo, Vector2Int objectPos)
        {
            foreach (var item in wo)
            {
                CarrySingle(item, objectPos);
            }
            return this;
        }

        public Animal Carry(int itemCode, int amount, Vector2Int destination)
        {
            for (int i = 0; i < amount; i++)
            {
                if (!CarrySingle(itemCode, destination, out var wo))
                {
                    break;
                }
            }
            return this;
        }

        public void DropdownAllInBag()
        {
            for (int i = bag.Count - 1; i >= 0; i--)
            {
                WorldObject item = bag[i];
                Dropdown(item);
                bag.Remove(item);
            }
        }

        private void Dropdown(WorldObject wo)
        {
            wo.OnBeDropDown();
            bag.Remove(wo);
        }

        public void Dropdown(WorldObject[] wo)
        {
            for (int i = wo.Length - 1; i >= 0; i--)
            {
                WorldObject item = wo[i];
                Dropdown(item);
                bag.Remove(item);
            }
        }

        public void AddWanderWork()
        {
            workTracer.AddWork(new WanderWork(this));
        }

        public Animal GoToLoc(Vector2Int target, MoveType moveType = MoveType.walk)
        {
            this.healthTracer.isSleeping = false;
            pathTracer.GoToLoc(target, moveType);
            return this;
        }

        public Animal GoToLocToil(Vector2Int target, MoveType moveType = MoveType.walk, UnityAction OnToilEnd = null)
        {
            this.healthTracer.isSleeping = false;
            if (this is Humanbeing humanbeing)
            {
                GoToLocWork toil = new GoToLocWork(humanbeing, target, OnToilEnd);
                workTracer.AddToil(toil);
            }
            return this;
        }

        public Animal PickUp(WorldObject[] worldObjects, Vector2Int startPoint)
        {
            this.healthTracer.isSleeping = false;
            PickUpToil toil = new PickUpToil(this, worldObjects, startPoint);
            workTracer.AddToil(toil);
            return this;
        }

        public Animal DropDownAll()
        {
            this.healthTracer.isSleeping = false;
            DropDownAllToil toil = new DropDownAllToil(this);
            workTracer.AddToil(toil);
            return this;
        }

        public override void Tick()
        {
            base.Tick();
            if (IsDead && deadFlag) return;
            healthTracer?.Tick();
            workTracer?.Tick();
            pathTracer?.Tick();
        }
    }

    public enum MotionStatus
    {
        Idle,
        Running,
    }

    public enum Face
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
    }
}

