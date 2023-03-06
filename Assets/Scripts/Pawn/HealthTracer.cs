using JetBrains.Annotations;
using ProcedualWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LittleWorld
{
    public class HealthTracer
    {
        public float curHealth;
        public float maxHealth;
        public float curHunger;
        public float maxHunger;
        public float curSleep;
        public float maxSleep;
        public Age age;

        public HealthTracer(float maxHealth, float maxHunger, float maxSleep, Age age)
        {
            this.maxHealth = maxHealth;
            this.curHealth = maxHealth;
            this.maxHunger = maxHunger;
            this.curHunger = maxHunger;
            this.maxSleep = maxSleep;
            this.curSleep = maxSleep;
            this.age = age;
        }

        public void Tick()
        {
            this.age.Tick();
        }

        internal void GetDamage(float damage)
        {
            var lastHealth = curHealth;
            var expectHealth = curHealth - damage;
            curHealth = Mathf.Max(0, expectHealth);
            Debug.Log($"受到伤害，curHealth:{lastHealth}->{curHealth} ");
        }

        public bool isDead => curHealth <= 0;

        public struct Age
        {
            public int year;
            public int day;
            public int hour;
            public int min;

            public Age(int yearAge, int dayAge = 0, int hourAge = 0, int minAge = 0)
            {
                this.year = yearAge;
                this.day = dayAge;
                this.hour = hourAge;
                this.min = minAge;
            }

            public override string ToString()
            {
                return $"{year}年{day}天";
            }

            public void AddSingleDay()
            {
                day++;
                EventCenter.Instance.Trigger(EventName.LIVING_AGE_DAY_CHANGE, this);
                if (day >= 30)
                {
                    day = 1;
                    if (day >= 120)
                    {
                        year++;
                        EventCenter.Instance.Trigger(EventName.LIVING_AGE_YEAR_CHANGE, this);
                    }
                }
            }

            public void Tick()
            {
                min++;
                if (min >= 60)
                {
                    min = 0;
                    hour++;
                    if (hour >= 24)
                    {
                        hour = 0;
                        AddSingleDay();
                    }
                }
            }
        }


    }
}
