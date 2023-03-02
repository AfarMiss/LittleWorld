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

        public bool isDead => curHealth <= 0;

        public struct Age
        {
            public int yearAge;
            public int dayAge;
            public int hourAge;
            public int minAge;

            public Age(int yearAge, int dayAge = 0, int hourAge = 0, int minAge = 0)
            {
                this.yearAge = yearAge;
                this.dayAge = dayAge;
                this.hourAge = hourAge;
                this.minAge = minAge;
            }

            public override string ToString()
            {
                return $"{yearAge}年{dayAge}天";
            }
        }


    }
}
