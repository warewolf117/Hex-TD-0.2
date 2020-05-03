using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MissilePooler : MonoBehaviour
{
    public GameObject prefab;

    private Queue<GameObject> availabelObjects = new Queue<GameObject>();

    public static MissilePooler Instance
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
        for (int i = 0; i < 5; i++)
        {
            var instanceToAdd = Instantiate(prefab);
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
