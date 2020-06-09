using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
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

    public static bool WallTopRightDestroyed = false;
    public static bool WallBottomRightDestroyed = false;
    public static bool WallRightDestroyed = false;
    public static bool WallTopLeftDestroyed = false;
    public static bool WallBottomLeftDestroyed = false;
    public static bool WallLeftDestroyed = false;

    bool topLeft = false;
    bool topRight = false;
    bool Left = false;
    bool Right = false;
    bool bottomLeft = false;
    bool bottomRight = false;

    bool meshTargetChanged = false;

    readonly string TagEnemyTopRight = "EnemyTopRight";
    readonly string TagEnemyTopLeft = "EnemyTopLeft";
    readonly string TagEnemyRight = "EnemyRight";
    readonly string TagEnemyLeft = "EnemyLeft";
    readonly string TagEnemyBottomRight = "EnemyBottomRight";
    readonly string TagEnemyBottomLeft = "EnemyBottomLeft";


    public void MoveTarget(Transform moveTarget)
    {
        target = moveTarget;
    }

    void Start()
    {
        currentSpeed = startingSpeed;

        if (gameObject.CompareTag(TagEnemyTopRight))
        {
            topRight = true;
            if (WallTopRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
        }
        else if (gameObject.CompareTag(TagEnemyTopLeft))
        {
            topLeft = true;
            if (WallTopLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
        }
        else if (gameObject.CompareTag(TagEnemyRight))
        {
            Right = true;
            if (WallRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
        }
        else if(gameObject.CompareTag(TagEnemyLeft))
        {
            Left = true;
            if (WallLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
        }
        else if (gameObject.CompareTag(TagEnemyBottomRight))
        {
            bottomRight = true;
            if (WallBottomRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
        }
        else if (gameObject.CompareTag(TagEnemyBottomLeft))
        {
            bottomLeft = true;
            if (WallBottomLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
            }
            else
            {
                if (gameObject.activeSelf)
                {
                    navMeshAgent.destination = target.position;
                }
            }
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

        if (meshTargetChanged)
            return;

        if (topRight)
        {
            if (WallTopRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }
        else if(topLeft)
        {
            if (WallTopLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }
        else if (Right)
        {
            if (WallRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }

        else if (Left)
        {
            if (WallLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }
        else if (bottomRight)
        {
            if (WallRightDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }
        else if (bottomLeft)
        {
            if (WallLeftDestroyed)
            {
                navMeshAgent.destination = CenterTarget.position;
                meshTargetChanged = true;
            }
        }
    }
}
   
    
