using LittleWorld.MapUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static LittleWorld.HealthTracer;

namespace LittleWorld.Item
{
    public class Living : WorldObject, IEatable
    {

        protected HealthTracer healthTracer;
        public bool IsDead => healthTracer.isDead;
        public Age Age => healthTracer.age;
        public float Hp => healthTracer.curHealth;
        public float HpPercent => healthTracer.curHealth / healthTracer.maxHealth;

        public bool eatable => healthTracer != null && healthTracer.isDead;
        public bool isSleeping => healthTracer.isSleeping;

        private float _maxNutrition = 0.2f;

        private float _leftNutrition;

        public string itemName => ItemName;

        public float eatDuration => 2f;

        public float maxNutrition => _maxNutrition;

        public float leftNutrition => _leftNutrition;

        public bool canEatPartly => true;

        public Living(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            this.EventRegister<GameTime>(EventName.GAME_TICK, OnGameTick);
            _leftNutrition = _maxNutrition;
        }

        /// <summary>
        /// 被食用者吃下
        /// </summary>
        /// <param name="needNutrition"></param>
        /// <returns></returns>
        public void BeEaten(HealthTracer healthTracer)
        {
            var needHunger = healthTracer.maxHunger - healthTracer.curHunger;
            if (needHunger > _leftNutrition)
            {
                healthTracer.curHunger += _leftNutrition;
                EatenTotally();
            }
            else
            {
                healthTracer.curHunger = healthTracer.maxHunger;
                if (canEatPartly)
                {
                    _leftNutrition -= needHunger;
                }
                else
                {
                    EatenTotally();
                }
            }
        }

        public void EatenTotally()
        {
            _leftNutrition = 0;
            OnBeEatenDispose();
        }

        private void OnGameTick(GameTime arg0)
        {

        }

        public override Sprite GetCurrentSprite()
        {
            return null;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public virtual void OnBeEatenDispose()
        {
        }
    }
}
