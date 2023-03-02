using LittleWorld.MapUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static LittleWorld.HealthTracer;

namespace LittleWorld.Item
{
    public class Living : WorldObject
    {

        protected HealthTracer healthTracer;
        public bool IsDead => healthTracer.isDead;
        public Age Age => healthTracer.age;
        public float Hp => healthTracer.curHealth;
        public float HpPercent => healthTracer.curHealth / healthTracer.maxHealth;
        public Living(int itemCode, Vector2Int gridPos, Map map = null) : base(itemCode, gridPos, map)
        {
            EventCenter.Instance.Register<GameTime>(EventName.GAME_TICK, OnGameTick);
        }

        private void OnGameTick(GameTime arg0)
        {
            throw new NotImplementedException();
        }

        public override Sprite GetSprite()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
