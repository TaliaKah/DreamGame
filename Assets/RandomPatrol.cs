using UnityEngine;
using UnityEngine.AI;

public class RandomPatrol : MonoBehaviour
{
    public float patrolRadius = 10f;  // Rayon de patrouille
    public float patrolInterval = 5f; // Intervalle entre les destinations de patrouille

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolDestination;
    private float timer = 0f;

    private bool isMoving = true;

    public void MovingPNJ()
    {
        isMoving = true;
    }

    public void StopMovingPNJ()
    {
        isMoving = false;
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if(isMoving)
        {        // Si le NavMesh Agent a atteint sa destination ou si le temps d'attente est écoulé
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
