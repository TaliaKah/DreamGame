using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovements : MonoBehaviour
{
    public GameObject finalPosition;
    public GameObject prisonPosition;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public void GoingToCastle()
    {
        navMeshAgent.Warp(finalPosition.transform.position);
        Debug.Log($"{transform.name} is in castle");
    }

    public void GoingToJail()
    {
        navMeshAgent.Warp(prisonPosition.transform.position);
        Debug.Log($"{transform.name} is going to jail");
    }
    
    public void StopMoving()
    {
        navMeshAgent.isStopped = true;
        Debug.Log($"{transform.name} have stopped moving");
    }

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}
