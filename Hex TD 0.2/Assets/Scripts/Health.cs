using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
   

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health < 1)
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
