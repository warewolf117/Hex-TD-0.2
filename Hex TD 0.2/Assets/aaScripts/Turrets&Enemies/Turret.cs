using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SocialPlatforms;

public class Turret : MonoBehaviour
{
    private new AudioSource audio;
    private Transform target;
    private Health targetEnemy;
    private BasicMovement targetEnemyM;


    BulletPooler bulletPooler;
    MissilePooler missilePooler;

    [Header("General")]

    public int range = 15;
    public float fireRate = 1f;
    public int bulletDamage;

    public static float rangeRender; 
    public float healthStatic;
    public int impactDamageStatic;

    [Header("Use Bullets")]

    public bool useBullet = false;
    public bool useMissile = false;
    public bool focusBack = false;
    private float fireCountdown = 0f;

    [Header("Use Laser")]

    public bool useLaser = false;

    public int LaserDamage;

    public float Slowpct = 0.3f;

    public float turnSpeed = 10f;

    [Header("Unity Setup Fields")]

    GameObject[] enemies;
    string[] allTags;

    int turretSector;

    public Transform firePoint;
    public Transform partToRotate;
    public LineRenderer lineRenderer;
    public GameObject turretGhost;



    void Start()
    {

        rangeRender = range;
      //  healthStatic = this.GetComponent<Health>().max_health;

        if (useLaser == true)
        {
            impactDamageStatic = LaserDamage;
        }
        else
        {
            impactDamageStatic = bulletDamage;
        }

    //   if (useLaser == true)
    //    {
    //        impactDamageStatic = bulletDamage;
    //    }


        audio = GetComponent<AudioSource>();
        bulletPooler = BulletPooler.Instance;
        missilePooler = MissilePooler.Instance;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  //Calls Update target twice per second (to avoid it looking for a new target too fast)

    }

    public void NodeSectionTargetingShit(int nodeSector)
    {
        turretSector = nodeSector;
    }

   

    void UpdateTarget()
    {
        if (gameObject.tag == "GhostTurret")
            return;

        if (turretSector == 1)
        {
            enemies = GameObject.FindGameObjectsWithTag("EnemyTopLeft");
        }
        if (turretSector == 2)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag("EnemyTopLeft");
            var enemy2 = GameObject.FindGameObjectsWithTag("EnemyTopRight");
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        if (turretSector == 3)
        {
            enemies = GameObject.FindGameObjectsWithTag("EnemyTopRight");
        }
        if (turretSector == 4)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag("EnemyTopRight");
            var enemy2 = GameObject.FindGameObjectsWithTag("EnemyRight");
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        if (turretSector == 5)
        {
            enemies = GameObject.FindGameObjectsWithTag("EnemyRight");
        }
        if (turretSector == 6)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag("EnemyBottomRight");
            var enemy2 = GameObject.FindGameObjectsWithTag("EnemyRight");
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        if (turretSector == 7)
        {
            enemies = GameObject.FindGameObjectsWithTag("EnemyBottomRight");
        }
        if (turretSector == 8)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag("EnemyBottomRight");
            var enemy2 = GameObject.FindGameObjectsWithTag("EnemyBottomLeft");
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        if (turretSector == 9)
        {
            enemies = GameObject.FindGameObjectsWithTag("EnemyBottomLeft");
        }
        if (turretSector == 10)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag("EnemyBottomLeft");
            var enemy2 = GameObject.FindGameObjectsWithTag("EnemyLeft");
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        if (turretSector == 11)
        {
            enemies = GameObject.FindGameObjectsWithTag("EnemyLeft");
        }
        if (turretSector == 12)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag("EnemyLeft");
            var enemy2 = GameObject.FindGameObjectsWithTag("EnemyTopLeft");
            enemies = enemy1.Concat(enemy2).ToArray();
        }

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
                audio.Stop();
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
        targetEnemy.takeDamageLaser(LaserDamage * Time.deltaTime);
        audio.Play();
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
        if (useBullet)
        {
            GameObject bulletGO = BulletPooler.Instance.GetFromPool();
            audio.PlayOneShot(audio.clip);
            bulletGO.transform.position = firePoint.position;
            bulletGO.transform.rotation = firePoint.rotation;
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.damage = bulletDamage;


            if (bullet != null)
                bullet.Seek(target);
        }
        if (useMissile)
        {
            GameObject missileGO = MissilePooler.Instance.GetFromPool();
            audio.PlayOneShot(audio.clip);
            missileGO.transform.position = firePoint.position;
            missileGO.transform.rotation = firePoint.rotation;
            Missile missile = missileGO.GetComponent<Missile>();


            if (missile != null)
                missile.Seek1(target);
        }

    }


    // Shows turret range if selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}