using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PolicemanMovements : MonoBehaviour
{
    public GameObject prison;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public void GoingToJail()
    {
        StopMoving();
        navMeshAgent.Warp(prison.transform.position);
        Debug.Log(transform.name + "TP at prison position : " + transform.position);
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
