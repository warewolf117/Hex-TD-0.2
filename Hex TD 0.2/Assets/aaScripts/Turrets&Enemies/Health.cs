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
    public float TotalDamage = 0;

    float laserPopupTimer = 0f;

    public static int deadWallCounter = 1;

    public static bool gameOver = false;

    void Start()
    {
        cur_health = max_health;

    }


    public void takeDamage(float amount)
    {

        if(!gameOver)
        {
            DamagePopup2.Create(gameObject.transform.position, amount);
        }



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

    public void takeDamageLaser(float amount)
    {

        TotalDamage += amount;
        float f = TotalDamage;
        f = Mathf.Round(f * 10.0f) * 0.1f;

        if (laserPopupTimer <= 0f)
        {
            if (!gameOver)
            {
                DamagePopup2.CreateLaser(gameObject.transform.position, f);
                laserPopupTimer = 0.15f;
            }


        }


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
            TotalDamage = 0;
        }
    }

    public void Die()
    {
        // Destroy literally erases an objects existence, thats why I kept the spawner away from the turrets
        // cus if the turret kills the spawner then spawns will stop 

        if (gameObject.tag == "EnemyTopLeft" || gameObject.tag == "EnemyTopRight" || gameObject.tag == "EnemyLeft" ||
            gameObject.tag == "EnemyRight" || gameObject.tag == "EnemyBottomLeft" || gameObject.tag == "EnemyBottomRight")
        {
            Destroy(this.gameObject);
            PlayerStats.money += worth;
            Wave.EnemiesAlive--;
            WaveSpawnerTopRight_Main.EnemyCount--;
        }


        if (gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
            deadWallCounter++;
            Debug.Log(deadWallCounter);
           
        }

        if (gameObject.tag == "Turret")
        {
            Destroy(this.gameObject);

        }



    }



    // Update is called once per frame
    void Update()
    {

        laserPopupTimer -= Time.deltaTime;
    }
}
