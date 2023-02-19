using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LittleWorld
{
    public class HealthTracer
    {
        public float curHealth;
        public float maxHealth;

        public HealthTracer(float maxHealth)
        {
            this.maxHealth = maxHealth;
            this.curHealth = maxHealth;
        }

        public bool isDead => curHealth <= 0;

    }
}
