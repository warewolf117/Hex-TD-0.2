﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float attackSpeed;

    private float damageCountdown = 0f;

    public Transform target;

    private bool CollidedWithTurret = false;
    private bool CollidedWithWall = false;

    Collision collisionTurret = null;
    Collision collisionWall = null;

    GameObject CollisionTurret;
    GameObject CollisionWall;



    public void OnCollisionEnter(Collision collision)
    {     
        if(collision.transform.tag == "Turret")
        {
            CollidedWithTurret = true;
            Debug.Log("Don't touch my banana, boi");
            this.collisionTurret = collision;
            CollisionTurret = collision.transform.gameObject;
        }

        if (collision.transform.tag == "Wall")
        {
            CollidedWithWall = true;
            this.collisionWall = collision;
            CollisionWall = collision.transform.gameObject;
        }
    }

    public void OnCollisionExit(Collision collision)
    {       
        if (collision.transform.tag == "Turret")
        {
            CollidedWithTurret = false;
            Debug.Log("Thanks, boi");
            this.collisionTurret = collision;
            CollisionTurret = null;
        }
        if (collision.transform.tag == "Wall")
        {
            CollidedWithWall = false;
            this.collisionWall = collision;
            CollisionWall = null;
        }
    }

    private void Update()
    {
        damageCountdown -= Time.deltaTime;

        if (CollidedWithWall)
        {

            if (CollisionWall != null)
            {
                if (damageCountdown <= 0)
                {
                    Debug.Log("Damaging Wall");
                    Health healthScript = collisionWall.transform.gameObject.GetComponent<Health>();
                    healthScript.cur_health -= damage;

                    damageCountdown = 1f / attackSpeed;


                    if (healthScript.cur_health <= 0)
                    {
                        CollidedWithWall = false;
                        healthScript.Die();
                    }
                }
            }
        }

        if (CollidedWithTurret)
        {
            if (CollisionTurret != null)
            {
            if (damageCountdown <= 0)
            {
                Debug.Log("Punching your Banana");
                Health healthScript = collisionTurret.transform.gameObject.GetComponent<Health>();
                healthScript.cur_health -= damage;

                damageCountdown = 1f / attackSpeed;


                if (healthScript.cur_health <= 0)
                {
                    CollidedWithTurret = false;
                    healthScript.Die();
                }
            }
            }
        }
    }

}





