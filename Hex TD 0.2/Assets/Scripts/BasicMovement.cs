using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMovement : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform moveTarget;
    public Transform spawnPoint;

    public float startingSpeed = 1.5f;

    [HideInInspector]
    public float currentSpeed;

    private bool slowed = false;

      
    void Start()
    {
        currentSpeed = startingSpeed;

        if (gameObject.activeSelf)
        {
            //navMeshAgent.destination = spawnPoint.position;
            navMeshAgent.destination = moveTarget.position;
        }
        else
        {

            navMeshAgent.destination = spawnPoint.position;
            //navMeshAgent.destination = moveTarget.position;

            
       }

    }

    public void Slow(float pct)
    {
        currentSpeed = startingSpeed * (1f - pct);
        slowed = true;
        
    }


    void Update()
    {
        if (slowed == true)
        {
            navMeshAgent.speed = currentSpeed;
          
        }
        else
        {
            navMeshAgent.speed = startingSpeed;
        }
        
        slowed = false;

    }
}
   
    
