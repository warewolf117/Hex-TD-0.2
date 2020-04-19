using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float damage = 30f;
    public float speed = 70f;
    public float SplashRadius = 0f;
    public GameObject impactEffect;

    Vector3 TargetPosition;
    Vector3 dir;

    private bool TargetAquired = false;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {



        TargetAquired = true;
        float distancePerFrame = speed * Time.deltaTime;

       
        if (TargetAquired == true && target != null)
        {
            TargetPosition = target.position;
            dir = target.position - transform.position;
            transform.Translate(dir.normalized * distancePerFrame, Space.World); //moves the bullet
            transform.LookAt(target);

        }

        if (TargetAquired == true && target == null)
        {
            dir = TargetPosition - transform.position;
            transform.Translate(dir.normalized * distancePerFrame, Space.World); //moves the bullet
            transform.LookAt(target);


        }

        if (dir.magnitude <= distancePerFrame)
        {

            HitTarget();
            Destroy(gameObject);
            TargetAquired = false;
            return;

        }


    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        if (SplashRadius > 0f)
        {
            Explode();
        }
        else
        {
            if (target != null)
            {
                Damage(target);
            }

        }

        void Explode()
        {
            //OverlapSphere creates a sphere and checks for all colliders that are in range of the sphere. Collider array to store all objects hit by sphere.
            Collider[] colliders = Physics.OverlapSphere(transform.position, SplashRadius);

            foreach (Collider collider in colliders) //for each object hit by the sphere, if tagged as Enemy then damage.
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                }
            }
        }

        void Damage(Transform target)
        {
            Health healthScript = target.transform.gameObject.GetComponent<Health>();
            healthScript.cur_health -= damage;

            if (healthScript.cur_health <= 0)
            {
                healthScript.Die();
            }

        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SplashRadius);
    }
}
