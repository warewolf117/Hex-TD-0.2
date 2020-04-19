﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float max_health = 5000f;
    public float cur_health = 0f;


    void Start()
    {
        cur_health = max_health;
    }


    public void TakeDamage(float amount)
    {
        cur_health -= amount;


        if (cur_health < 1)
        {
            Die();
        }

    }

    public void Die()
    {
        // Destroy literally erases an objects existence, thats why I kept the spawner away from the turrets
        // cus if the turret kills the spawner then spawns will stop 
        Destroy(this.gameObject);

    }



    // Update is called once per frame
    void Update()
    {

    }
}
