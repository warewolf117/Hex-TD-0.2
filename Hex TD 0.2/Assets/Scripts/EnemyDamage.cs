using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public Transform target;
    


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 1)
        {
            Health health = target.transform.GetComponent<Health>();
            health.TakeDamage(damage);
            Debug.Log("YOU HIITTTTTTTTTTTTT ITT!!!!!!!!!!!!!");
        }

           

    }

   
    
}

