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

        public float nutrition => 0.5f;

        public string itemName => ItemName;

        public Living(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            this.EventRegister<GameTime>(EventName.GAME_TICK, OnGameTick);
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
    }
}
