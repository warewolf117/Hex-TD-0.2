using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SocialPlatforms;

public class Turret : MonoBehaviour
{
    private AudioSource Maudio; 
    private Transform target;
    private Health targetEnemy;
    private BasicMovement targetEnemyM;


    BulletPooler bulletPooler;
    MissilePooler missilePooler;

    [Header("General")]

    public int range = 15;
    public float fireRate = 1f;
    private float startFireRate;
    public int bulletDamage;
    public int poisonDamage;
    public int aoeDamage;

    public static float rangeRender; 
    public float healthStatic;
    public int impactDamageStatic;

    [Header("Use Bullets")]

    public bool useBullet = false;
    public bool useMissile = false;
    public bool usePoison = false;
    public bool useMinigun = false;
    public bool useAOE = false;
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

    private string GhostTurret = "GhostTurret";
    private string EnemyTopLeft = "EnemyTopLeft";
    private string EnemyTopRight = "EnemyTopRight";
    private string EnemyRight = "EnemyRight";
    private string EnemyLeft = "EnemyLeft";
    private string EnemyBottomRight = "EnemyBottomRight";
    private string EnemyBottomLeft = "EnemyBottomLeft";

 
    void Start()
    {
        startFireRate = fireRate;
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


        Maudio = GetComponent<AudioSource>();
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
        if (gameObject.CompareTag(GhostTurret))
            return;

        if (turretSector == 1)
        {
            enemies = GameObject.FindGameObjectsWithTag(EnemyTopLeft);
        }
        else if (turretSector == 2)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag(EnemyTopLeft);
            var enemy2 = GameObject.FindGameObjectsWithTag(EnemyTopRight);
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        else if (turretSector == 3)
        {
            enemies = GameObject.FindGameObjectsWithTag(EnemyTopRight);
        }
        else if (turretSector == 4)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag(EnemyTopRight);
            var enemy2 = GameObject.FindGameObjectsWithTag(EnemyRight);
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        else if (turretSector == 5)
        {
            enemies = GameObject.FindGameObjectsWithTag(EnemyRight);
        }
        else if (turretSector == 6)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag(EnemyBottomRight);
            var enemy2 = GameObject.FindGameObjectsWithTag(EnemyRight);
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        else if (turretSector == 7)
        {
            enemies = GameObject.FindGameObjectsWithTag(EnemyBottomRight);
        }
        else if (turretSector == 8)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag(EnemyBottomRight);
            var enemy2 = GameObject.FindGameObjectsWithTag(EnemyBottomLeft);
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        else if (turretSector == 9)
        {
            enemies = GameObject.FindGameObjectsWithTag(EnemyBottomLeft);
        }
        else if (turretSector == 10)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag(EnemyBottomLeft);
            var enemy2 = GameObject.FindGameObjectsWithTag(EnemyLeft);
            enemies = enemy1.Concat(enemy2).ToArray();
        }
        else if (turretSector == 11)
        {
            enemies = GameObject.FindGameObjectsWithTag(EnemyLeft);
        }
        else if (turretSector == 12)
        {
            var enemy1 = GameObject.FindGameObjectsWithTag(EnemyLeft);
            var enemy2 = GameObject.FindGameObjectsWithTag(EnemyTopLeft);
            enemies = enemy1.Concat(enemy2).ToArray();
        }

        float shortestDistance = Mathf.Infinity; //sets shortestDistance to infinity if there is no enemy
        float furthestDistance = Mathf.NegativeInfinity;
        GameObject currentEnemy = null;
        GameObject nearestEnemy = null;
        GameObject furthestEnemy = null;

        if (usePoison)
        {
            foreach (GameObject enemy in enemies)
            {
                if (!enemy.GetComponent<Health>().isPoisoned)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position); //measures distance between turret and enemy

                    if (distance < shortestDistance && distance <= range)
                    {
                        shortestDistance = distance;
                        nearestEnemy = enemy;
                        currentEnemy = nearestEnemy;
                    }

                    if (currentEnemy != null)
                    {
                        target = currentEnemy.transform;
                        targetEnemy = currentEnemy.GetComponent<Health>();
                        targetEnemyM = currentEnemy.GetComponent<BasicMovement>();
                        return;
                    }
                    else
                    {
                        target = null;
                    }
                }

            }
            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<Health>().isPoisoned)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position); //measures distance between turret and enemy

                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        nearestEnemy = enemy;
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
        } 

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
        else if (!focusBack || useAOE)//Regular Targeting
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
                Maudio.Stop();
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;

                }


            }
            if (useMinigun)
            {
                fireRate = startFireRate;
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
                if (useMinigun)
                {
                    if (fireRate < 10)
                    fireRate += 0.5f;
                }
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
        Maudio.Play();
        targetEnemyM.Slow(Slowpct);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, new Vector3(target.position.x, target.position.y + 0.5f, target.position.z));
    }

    void Shoot()
    {
        if (useBullet)
        {
            GameObject bulletGO = BulletPooler.Instance.GetFromPool();
            Maudio.PlayOneShot(Maudio.clip);
            bulletGO.transform.position = firePoint.position;
            bulletGO.transform.rotation = firePoint.rotation;
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.damage = bulletDamage;

            if (bullet != null)
                bullet.Seek(target);
        }
        else if (useMissile)
        {
            GameObject missileGO = MissilePooler.Instance.GetFromPool();
            Maudio.PlayOneShot(Maudio.clip);
            missileGO.transform.position = firePoint.position;
            missileGO.transform.rotation = firePoint.rotation;
            Missile missile = missileGO.GetComponent<Missile>();
            missile.damage = bulletDamage;

            if (missile != null)
                missile.Seek1(target);
        }
        else if (usePoison)
        {
            target.GetComponent<Health>().isPoisoned = true;
            GameObject PoisonGO = PoisonPooler.Instance.GetFromPool();
            Maudio.PlayOneShot(Maudio.clip);
            PoisonGO.transform.position = firePoint.position;
            PoisonGO.transform.rotation = firePoint.rotation;
            Poison poison = PoisonGO.GetComponent<Poison>();
            poison.impactdamage = bulletDamage;
            poison.damage = poisonDamage;

            if (poison != null)
                poison.Seek(target);
        }
        else if (useAOE)
        {
            foreach (GameObject enemy in enemies)
            {
                if (enemy == null)
                    return;

                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                
                if (distance <= range)
                {

                    Health healthScript = enemy.transform.gameObject.GetComponent<Health>();
                    healthScript.takeDamage(aoeDamage);

                }
            }

        }

    }

    // Shows turret range if selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Leve
}