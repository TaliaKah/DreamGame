using UnityEngine;
using UnityEngine.AI;

public class KnightMovement : MonoBehaviour
{
    public float patrolRadius = 10f;  // Rayon de patrouille
    public float patrolInterval = 5f; // Intervalle entre les destinations de patrouille

    public GameObject taverneEntrance;

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolDestination;
    private float timer = 0f;

    private DecisionManager decisionManager;

    enum MovingStatus
    {
        Stop,
        RandomlyMoving,
        GoingToTavern
    }

    private MovingStatus movingStatus;

    public void RandomlyMoving()
    {
        movingStatus = MovingStatus.RandomlyMoving;
        SetRandomDestination();
        Debug.Log($"{transform.name} is randomly moving");
    }

    public void GoingToTavern()
    {
        movingStatus = MovingStatus.GoingToTavern;
        navMeshAgent.SetDestination(taverneEntrance.transform.position);
        Debug.Log($"{transform.name} is going to tavern.");
    }

    public void StopMoving()
    {
        movingStatus = MovingStatus.Stop;
        navMeshAgent.SetDestination(transform.position);
        Debug.Log($"{transform.name} have stopped moving");
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        decisionManager = FindObjectOfType<DecisionManager>();
        movingStatus = MovingStatus.RandomlyMoving;
        SetRandomDestination();
    }

    void Update()
    {
        if (movingStatus == MovingStatus.GoingToTavern)
        {
            if ((Mathf.Abs(transform.position.x - taverneEntrance.transform.position.x) < 2f && Mathf.Abs(transform.position.z - taverneEntrance.transform.position.z) < 2f))
            {
                StopMoving();
            }
        }
        // if (movingStatus == MovingStatus.RandomlyMoving)
        // {
        //     if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f && timer >= patrolInterval)
        //     {
        //         RandomlyMoving();
        //         timer = 0f;
        //     }

        //     timer += Time.deltaTime;
        // }
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
