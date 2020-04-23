using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Health targetEnemy;
    private BasicMovement targetEnemyM;


    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets (default)")]

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]

    public bool useLaser = false;

    public bool focusBack = false;

    public int damageOverTime = 30;

    public float Slowpct = 0.3f;

    public LineRenderer lineRenderer;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;


    public Transform firePoint;


    public bool shouldFire;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  //Calls Update target twice per second (to avoid it looking for a new target too fast)
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);  //looks for all objects with enemyTag
        float shortestDistance = Mathf.Infinity; //sets shortestDistance to infinity if there is no enemy
        float furthestDistance = Mathf.NegativeInfinity;
        GameObject nearestEnemy = null;
        GameObject furthestEnemy = null;



        if (focusBack == true)  //Back Targeting
        {
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position); //measures distance between turret and enemy

                if (distance > furthestDistance && distance <= range)
                {
                    furthestDistance = distance;
                    furthestEnemy = enemy;

                }

            }
            if (furthestEnemy != null && furthestDistance <= range)
            {
                target = furthestEnemy.transform;
                targetEnemy = furthestEnemy.GetComponent<Health>();
                targetEnemyM = furthestEnemy.GetComponent<BasicMovement>();
            }
            else
            {
                target = null;
            }
        }

        else //Regular Targeting
        {


            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position); //measures distance between turret and enemy

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestEnemy = enemy;

                }

            }
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<Health>();
                targetEnemyM = nearestEnemy.GetComponent<BasicMovement>();
            }
            else
            {
                target = null;
            }
        }
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;

                }


            }
            return; //no target, return and do nothing 
        }


        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }


    }

    void LockOnTarget()
    {
        // target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()

    {
        targetEnemy.takeDamage(damageOverTime * Time.deltaTime);
        targetEnemyM.Slow(Slowpct);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;


        }



        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);






    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }


    // Shows turret range if selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}