using LittleWorld.Item;
using LittleWorld.Jobs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleWorld.Item
{
    public class Animal : WorldObject
    {
        public MotionStatus motion = MotionStatus.Idle;
        protected PathNavigation pathTracer;
        protected AnimalInfo animalInfo;
        protected PawnHealthTracer healthTracer;
        protected WorkTracer workTracer;

        public Face faceTo => pathTracer.animalFace;
        public float moveSpeed => animalInfo.moveSpeed;

        public Animal(int itemCode, Vector2Int gridPos) : base(itemCode, gridPos)
        {
            animalInfo = ObjectConfig.ObjectInfoDic[itemCode] as AnimalInfo;
            workTracer = new NonAggressiveWorkTracer(this);
        }
        public void SetNavi(PathNavigation PawnPathTracer)
        {
            this.pathTracer = PawnPathTracer;
        }
        public override Sprite GetSprite()
        {
            return animalInfo.itemSprites[0];
        }

        public Sprite GetFaceSprite()
        {
            return GetSprite(faceTo);
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

        public void GoToLoc(Vector2Int target)
        {
            pathTracer.GoToLoc(target);
        }

        public override void Tick()
        {
            base.Tick();
            workTracer?.Tick();
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

