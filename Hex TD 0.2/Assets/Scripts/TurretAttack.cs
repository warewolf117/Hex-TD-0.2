using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    public float damage;
    public GameObject attackPrefab;
    public GameObject attackInstance;
    public BasicTargeting basicTargeting;
    public LayerMask layerMask;

    public float fireRate = .2f;
    public float fireCooldown;

    void Start()
    {
        basicTargeting = GetComponent<BasicTargeting>();
        attackInstance = GameObject.Instantiate(attackPrefab, transform.position, transform.rotation, transform);
        attackInstance.SetActive(false);
    }

        void Update()
    {
        if (basicTargeting.shouldFire)
        {
            if(attackInstance.activeSelf == false)
            attackInstance.SetActive(true);
            
            if (Time.time > fireCooldown)
            {
                CheckHit();
                fireCooldown = Time.time + fireRate;
            }
           

        } else
        {
            if (attackInstance.activeSelf)
                attackInstance.SetActive(false);
        }
    }
    void CheckHit()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            Health health = hit.transform.GetComponent<Health>();
            health.TakeDamage(damage);
        }
    }
}
