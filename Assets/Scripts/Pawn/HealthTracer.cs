using JetBrains.Annotations;
using LittleWorld.Item;
using ProcedualWorld;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace LittleWorld
{
    public class HealthTracer : TracerBase
    {
        public float curHealth;
        public float maxHealth;
        public float curHunger;
        public float maxHunger;
        public float curSleep;
        public float maxSleep;
        private Animal animal;
        public Age age;

        public bool deadFlag = false;

        public HealthTracer(float maxHealth, float maxHunger, float maxSleep, Age age, Animal animal)
        {
            this.maxHealth = maxHealth;
            this.curHealth = maxHealth;
            this.maxHunger = maxHunger;
            this.curHunger = maxHunger;
            this.maxSleep = maxSleep;
            this.curSleep = maxSleep;
            this.animal = animal;
            this.age = age;
        }

        public override void Tick()
        {
            this.age.Tick();
            this.curHunger -= 0.0002f;
            this.curSleep -= 0.0002f;

            EventCenter.Instance.Trigger<Animal>(EventName.UPDATE_LIVING_STATE, this.animal);

            if (isDead && !deadFlag)
            {
                this.animal.Die();
                deadFlag = true;
            }
        }

        internal void GetDamage(float damage)
        {
            var lastHealth = curHealth;
            var expectHealth = curHealth - damage;
            curHealth = Mathf.Max(0, expectHealth);
            Debug.Log($"{this.animal.ItemName}_{this.animal.instanceID}受到伤害,curHealth:{lastHealth}->{curHealth} ");
        }

        public bool isDead => curHealth <= 0 || curHunger <= 0 || curSleep <= 0;

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
                if (min >= 180)
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
