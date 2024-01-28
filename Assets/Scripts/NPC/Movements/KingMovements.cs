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
        transform.position = finalPosition.transform.position;
        Debug.Log($"{transform.name} is in castle");
    }

    public void GoingToJail()
    {
        transform.position = prisonPosition.transform.position;
        Debug.Log($"{transform.name} is going to jail");
    }
    
    public void StopMoving()
    {
        Debug.Log($"{transform.name} have stopped moving");
    }

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}
