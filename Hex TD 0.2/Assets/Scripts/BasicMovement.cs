using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicMovement : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform moveTarget;
    public Transform spawnPoint;
     


    void Start()
    {
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

    


 


    void Update()
    {
        
    }
}
   
    
