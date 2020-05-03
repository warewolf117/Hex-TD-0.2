using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    public GameObject bulletPrefab;

    private Queue<GameObject> availabelObjects = new Queue<GameObject>();

    public static BulletPooler Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public GameObject GetFromPool()
    {
        if (availabelObjects.Count == 0)
            GrowPool();

            var instance = availabelObjects.Dequeue();
            instance.SetActive(true);
            return instance;
        
    }

    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(bulletPrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availabelObjects.Enqueue(instance);
    }




}
