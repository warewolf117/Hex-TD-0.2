﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public int damage = 30;
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
            BulletPooler.Instance.AddToPool(gameObject);
            //Destroy(gameObject);
            TargetAquired = false;
            return;

        }


    }

    void HitTarget()
    {
        damage = Random.Range(damage - (damage / 7), damage + (damage / 6));



        if (target != null)
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 0.2f);
            Damage(target);
        }


        void Damage(Transform target)
        {
            Health healthScript = target.transform.gameObject.GetComponent<Health>();

            healthScript.takeDamage(damage);



        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SplashRadius);
    }
}

