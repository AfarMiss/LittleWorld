using LittleWorld.Item;
using LittleWorld.Jobs;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static AI.MoveLeaf;
using static LittleWorld.HealthTracer;
using static LittleWorld.Item.Bullet;

namespace LittleWorld.Item
{
    public class Animal : Living
    {
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

        public PathTracer PathTracer { get => pathTracer; }
        private bool deadFlag => this.healthTracer != null && this.healthTracer.deadFlag;

        /// <summary>
        /// 注册被伤害时事件
        /// </summary>
        public Action OnBeHurt;
        public bool isEating => healthTracer.isEating;

        public Animal(int itemCode, Age age, Vector2Int gridPos) : base(itemCode, gridPos)
        {
            animalInfo = ObjectConfig.ObjectInfoDic[itemCode] as AnimalInfo;
            workTracer = new NonAggressiveWorkTracer(this);
            healthTracer = new HealthTracer(100, 0.9f, 1f, age, this);
            pathTracer = new PathTracer(this);
            gearTracer = new GearTracer(this);

            this.workTracer.OnEnable();
            this.healthTracer.OnEnable();
            this.pathTracer.OnEnable();
        }

        public Animal SleepToil(Vector2Int pos)
        {
            workTracer.AddToil(new SleepWork(this, pos));
            return this;
        }

        public Animal EatToil(IEatable eatable)
        {
            workTracer.AddToil(new EatWork(this, eatable));
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
                animal = this,
                humanbeing = damageSource as Humanbeing,
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

        public Animal GoToLocToil(Vector2Int target, MoveType moveType = MoveType.walk)
        {
            this.healthTracer.isSleeping = false;
            pathTracer.GoToLoc(target, moveType);
            if (this is Humanbeing humanbeing)
            {
                GoToLocWork toil = new GoToLocWork(humanbeing, target);
                workTracer.AddWork(toil);
                workTracer.AddToil(toil);
            }
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

