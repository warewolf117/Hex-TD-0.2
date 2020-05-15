using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class BasicMovement : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Transform target;
    public Transform CenterTarget;
    public float startingSpeed = 1.5f;


    [HideInInspector]
    public float currentSpeed;

    private bool slowed = false;




    public void MoveTarget(Transform moveTarget)
    {
        target = moveTarget;


    }

    void Start()
    {
        currentSpeed = startingSpeed;

        if (gameObject.activeSelf)
        {
            //navMeshAgent.destination = spawnPoint.position;
            navMeshAgent.destination = target.position;
        }

    }


  

    public void Slow(float pct)
    {
        currentSpeed = startingSpeed * (1f - pct);
        slowed = true;
        
    }

    void Update()
    {
        if (gameObject.tag == "EnemyTopRight")
        {
           GameObject HexWallTopRight = GameObject.Find("Hex Wall TopRight");
            if (!HexWallTopRight)
            {
                navMeshAgent.destination = CenterTarget.position;
            }            
        }
        if (gameObject.tag == "EnemyTopLeft")
        {
            GameObject HexWallTopLeft = GameObject.Find("Hex Wall TopLeft");
            if (!HexWallTopLeft)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
        }
        if (gameObject.tag == "EnemyRight")
        {
            GameObject HexWallRight = GameObject.Find("Hex Wall Right");
            if (!HexWallRight)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
        }
        if (gameObject.tag == "EnemyLeft")
        {
            GameObject HexWallLeft = GameObject.Find("Hex Wall Left");
            if (!HexWallLeft)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
        }
        if (gameObject.tag == "EnemyBottomRight")
        {
            GameObject HexWallBottomRight = GameObject.Find("Hex Wall BottomRight");
            if (!HexWallBottomRight)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
        }
        if (gameObject.tag == "EnemyBottomLeft")
        {
            GameObject HexWallBottomLeft = GameObject.Find("Hex Wall BottomLeft");
            if (!HexWallBottomLeft)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
        }



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
   
    
