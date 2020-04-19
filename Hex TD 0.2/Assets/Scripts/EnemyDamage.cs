using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float attackSpeed;

    private float damageCountdown = 0f;

    public Transform target;


    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        this.damageCountdown -= Time.deltaTime;

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, dir, out hit, 0.6f))
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





