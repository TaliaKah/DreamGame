using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyMovements : MonoBehaviour
{
    public float patrolRadius = 10f;  // Rayon de patrouille
    public float patrolInterval = 5f; // Intervalle entre les destinations de patrouille

    public GameObject finalPosition;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Vector3 patrolDestination;
    private float timer = 0f;

    private DecisionManager decisionManager;

    enum MovingStatus
    {
        Stop,
        RandomlyMoving,
        InCastle
    }

    private MovingStatus movingStatus;

    public void RandomlyMoving()
    {
        movingStatus = MovingStatus.RandomlyMoving;
        Debug.Log($"{transform.name} is randomly moving");
    }

    public void GoingToCastle()
    {
        movingStatus = MovingStatus.InCastle;
        Debug.Log($"{transform.name} is in castle");
    }
    
    public void StopMoving()
    {
        movingStatus = MovingStatus.Stop;
        Debug.Log($"{transform.name} have stopped moving");
    }

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        decisionManager = FindObjectOfType<DecisionManager>();
        movingStatus = MovingStatus.Stop;
    }

    void Update()
    {
        if (movingStatus == MovingStatus.RandomlyMoving)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f && timer >= patrolInterval)
            {
                SetRandomDestination();
                timer = 0f;
            }

            timer += Time.deltaTime;
            }
        else
        {
            navMeshAgent.SetDestination(transform.position);
        }
    }

    void SetRandomDestination()
    {
        // Générer une nouvelle destination aléatoire autour du PNJ
        Vector2 randomPatrolPoint = Random.insideUnitCircle * patrolRadius;
        Vector3 localPatrolDestination = new Vector3(randomPatrolPoint.x, 0f, randomPatrolPoint.y);

        // Convertir la destination locale en une position mondiale
        patrolDestination = transform.TransformPoint(localPatrolDestination);

        // Définir la nouvelle destination pour le NavMesh Agent
        navMeshAgent.SetDestination(patrolDestination);
    }

}
