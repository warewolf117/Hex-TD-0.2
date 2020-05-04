using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DmgPopUpPooler : MonoBehaviour
{
    public GameObject popUpPrefab;


    private Queue<GameObject> availablePopUps = new Queue<GameObject>();
  

    public static DmgPopUpPooler Instance
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
        if (availablePopUps.Count == 0)
            GrowPool();

        var instance = availablePopUps.Dequeue();
        instance.SetActive(true);
        return instance;

    }

    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(popUpPrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availablePopUps.Enqueue(instance);
    }
}
