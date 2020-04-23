using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float max_health = 5000f;
    public float cur_health = 0f;
    public Image healthBar;
    public int worth;
    private bool checkAlive = true;


    void Start()
    {
        cur_health = max_health;
    }


   public void takeDamage(float amount)
    {
       
        
        cur_health -= amount;
        healthBar.fillAmount = cur_health / max_health;
       

        if (cur_health <= 0 && checkAlive)
        {
            Die();
            checkAlive = false;
        }
    }

    public void Die()
    {
        // Destroy literally erases an objects existence, thats why I kept the spawner away from the turrets
        // cus if the turret kills the spawner then spawns will stop 

        if (gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            PlayerStats.money += worth;
            Spawner.enemiesLeft--;
            Wave.EnemiesAlive--;
            WaveSpawner.EnemyCount--;

            Debug.Log("enemies Alive:" + Wave.EnemiesAlive);
          //  Debug.Log("enemy count:" + WaveSpawner.EnemyCount);

            Debug.Log("ENEMY KILLED");
        }

       
        if (gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }




    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
