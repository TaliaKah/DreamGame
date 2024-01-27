using UnityEngine;
using UnityEngine.AI;

public class KnightMovement : MonoBehaviour
{
    public float patrolRadius = 10f;  // Rayon de patrouille
    public float patrolInterval = 5f; // Intervalle entre les destinations de patrouille

    public GameObject tavernPosition;
    public GameObject castlePosition;
    public GameObject mountainPosition;
    public GameObject riverPosition;

    private NavMeshAgent navMeshAgent;
    private Vector3 patrolDestination;
    private float timer = 0f;

    private DecisionManager decisionManager;

    enum MovingStatus
    {
        GoingToTavern,
        GoingToCastle,
        InRiver,
        InTavern,
        InCastle,
        InMountain,
    }

    private MovingStatus movingStatus;

    public void GoingToTavern()
    {
        movingStatus = MovingStatus.GoingToTavern;
        navMeshAgent.SetDestination(tavernPosition.transform.position);
        Debug.Log($"{transform.name} is going to tavern.");
    }

    public void GoingToCastle()
    {
        movingStatus = MovingStatus.GoingToCastle;
        navMeshAgent.SetDestination(castlePosition.transform.position);
        Debug.Log($"{transform.name} is going to castle.");
    }

    public void StopMoving()
    {
        navMeshAgent.SetDestination(transform.position);
        Debug.Log($"{transform.name} have stopped moving");
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    void GoingTo(MovingStatus status, GameObject position)
    {
        if ((Mathf.Abs(transform.position.x - position.transform.position.x) < 2f && Mathf.Abs(transform.position.z - position.transform.position.z) < 2f))
        {
            StopMoving();
            movingStatus = status;
        }
    }

    void Update()
    {
        if (movingStatus == MovingStatus.GoingToTavern)
        {
            GoingTo(movingStatus, tavernPosition);
        }
        if (movingStatus == MovingStatus.GoingToCastle)
        {
            GoingTo(movingStatus, castlePosition);
        }

        if (decisionManager.GetDecision(DecisionManager.Decision.RencontrerLeTavernier) && !(movingStatus == MovingStatus.InTavern))
        {
            transform.position = tavernPosition.transform.position;
            movingStatus = MovingStatus.InTavern;
        }
        if (decisionManager.GetDecision(DecisionManager.Decision.AllerALaMontagneDuDesespoir))
        {
            transform.position = mountainPosition.transform.position;
            movingStatus = MovingStatus.InMountain;
        }
        if (decisionManager.GetDecision(DecisionManager.Decision.AllerAuChateau) && !(movingStatus == MovingStatus.InCastle))
        {
            transform.position = castlePosition.transform.position;
        }
        if (riverPosition !=null && decisionManager.GetDecision(DecisionManager.Decision.DebuterQuete1))
        {
            transform.position = riverPosition.transform.position;
            movingStatus = MovingStatus.InRiver;
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
