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
        protected PathTracer pathTracer;
        protected AnimalInfo animalInfo;
        protected WorkTracer workTracer;

        public PathTracerRender RenderTracer;
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

        /// <summary>
        /// 注册被伤害时事件
        /// </summary>
        public Action OnBeHurt;

        public Animal(int itemCode, Age age, Vector2Int gridPos) : base(itemCode, gridPos)
        {
            animalInfo = ObjectConfig.ObjectInfoDic[itemCode] as AnimalInfo;
            workTracer = new NonAggressiveWorkTracer(this);
            healthTracer = new HealthTracer(100, 0.9f, 1f, age, this);
            pathTracer = new PathTracer(this);

            this.workTracer.OnEnable();
            this.healthTracer.OnEnable();
            this.pathTracer.OnEnable();
        }

        public override Sprite GetSprite()
        {
            return animalInfo.itemSprites[0];
        }

        public virtual void Die()
        {
            this.workTracer.OnDisable();
            this.healthTracer.OnDisable();
            this.pathTracer.OnDisable();
            this.ItemRender.OnDie();
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
                    return animalInfo.itemSprites[1];
                case Face.Down:
                    return animalInfo.itemSprites[0];
                case Face.Left:
                    return animalInfo.itemSprites[2];
                case Face.Right:
                    return animalInfo.itemSprites[2];
                default:
                    return animalInfo.itemSprites[1];
            }
        }

        public void AddWanderWork()
        {
            workTracer.AddWork(new WanderWork(this));
        }

        public void GoToLoc(Vector2Int target, MoveType moveType)
        {
            pathTracer.GoToLoc(target, moveType);
        }

        public override void Tick()
        {
            base.Tick();
            if (IsDead) return;
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

