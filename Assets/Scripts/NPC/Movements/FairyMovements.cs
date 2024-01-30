using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovements : MonoBehaviour
{
    public GameObject finalPosition;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public void GoingToCastle()
    {
        navMeshAgent.Warp(finalPosition.transform.position);
        Debug.Log($"{transform.name} is in castle");
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
