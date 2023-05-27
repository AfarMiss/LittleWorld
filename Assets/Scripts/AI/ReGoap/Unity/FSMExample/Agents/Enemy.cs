using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth = 0;
    public bool isAlive => curHealth > 0;
    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (!isAlive) return;
        if (curHealth <= 0)
        {
            Debug.Log(this.GetInstanceID() + "isDead!");
        }
    }
}
