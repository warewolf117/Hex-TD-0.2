using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float attackSpeed;
    private float attackdistance;
    public float range;

    private float damageCountdown = 0f;

    public Transform target;

    private bool CollidedWithTurret = false;
    Collision collision = null;
    GameObject CollisionObject;



    public void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.tag == "Turret")
        {
            CollidedWithTurret = true;
            Debug.Log("Don't touch my banana, boi");
            this.collision = collision;
            CollisionObject = collision.transform.gameObject;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        
        if (collision.transform.tag == "Turret")
        {
            CollidedWithTurret = false;
            Debug.Log("Thanks, boi");
            this.collision = collision;
            CollisionObject = null;
        }
    }

    private void Update()
    {
        WallTakeDamage();

        if (CollidedWithTurret)
        {
            if (CollisionObject != null)
            {
            if (damageCountdown <= 0)
            {
                Debug.Log("Punching your Banana");
                Health healthScript = collision.transform.gameObject.GetComponent<Health>();
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

    public void WallTakeDamage()
    {
        Vector3 dir = target.position - transform.position;

        this.damageCountdown -= Time.deltaTime;

        if(this.gameObject.name == "DaMiniBoss")
        {
            attackdistance = 1.7f;
        }    
        else
        {
            attackdistance = 0.7f;
        }

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, dir, out hit, attackdistance))
        {
            if (hit.transform.tag == "Wall")
            {
                if (this.damageCountdown <= 0)
                {
                    Health healthScript = hit.transform.gameObject.GetComponent<Health>();
                    healthScript.cur_health -= this.damage;

                    damageCountdown = 1f / attackSpeed;

                    

                    if (healthScript.cur_health <= 0)
                    {
                        healthScript.Die();
                    }
                }
            }
        }
    }

}





