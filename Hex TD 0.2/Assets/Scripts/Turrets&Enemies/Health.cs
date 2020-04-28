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
    public Turret turret;


    void Start()
    {
        cur_health = max_health;
        
    }


   public void takeDamage(float amount)
    {
        
        
       DamagePopup2.Create(gameObject.transform.position, amount);
        
       
       cur_health -= amount;
       healthBar.fillAmount = cur_health / max_health;
        if (healthBar.fillAmount < 0.8f && healthBar.fillAmount > 0.6f)
        {
            healthBar.color = new Color32(196, 255, 0, 100);
        }
        if (healthBar.fillAmount < 0.6f && healthBar.fillAmount > 0.4f)
        {
            healthBar.color = new Color32(247, 255, 0, 100);
        }
        if (healthBar.fillAmount < 0.4f && healthBar.fillAmount > 0.2f)
        {
            healthBar.color = new Color32(255, 162, 0, 100);
        }
        if (healthBar.fillAmount < 0.2f)
        {
            healthBar.color = new Color32(255, 43, 0, 100);
        }



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
