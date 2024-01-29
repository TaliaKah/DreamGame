using UnityEngine;
using UnityEngine.AI;

public class KnightMovement : MonoBehaviour
{

    public GameObject tavernPosition;
    public GameObject castlePosition;
    public GameObject mountainPosition;
    public GameObject riverPosition;

    private NavMeshAgent navMeshAgent;

    private DecisionManager decisionManager;

    enum MovingStatus
    {
        Stop,
        GoingToTavern,
        GoingToCastle,
        GoingToMountain,
        GoingToRiver
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
        navMeshAgent.isStopped = true;
        movingStatus = MovingStatus.Stop;
        Debug.Log($"{transform.name} have stopped moving");
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    void ArrivedAt(GameObject position)
    {
        if ((Mathf.Abs(transform.position.x - position.transform.position.x) < 2f && Mathf.Abs(transform.position.z - position.transform.position.z) < 2f))
        {
            StopMoving();
        }
    }

    public void TPAtTavern()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(tavernPosition.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
            Debug.Log(transform.name + "TP at tavern position : " + transform.position);
        }
    }

    public void TPAtMountain()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(mountainPosition.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
            Debug.Log(transform.name + "TP at mountain position : " + transform.position);
        }
    }

    public void TPAtCastle()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(castlePosition.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
            Debug.Log(transform.name + "TP at castle position : " + transform.position);
        }
    }

    public void TPAtRiver()
    {
        if (riverPosition != null)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(riverPosition.transform.position, out hit, 1.0f, NavMesh.AllAreas))
            {
                transform.position = hit.position;
                Debug.Log(transform.name + "TP at river position : " + transform.position);
            }
        }
    }


    private bool leaveRiver = true;

    void Update()
    {
        if (movingStatus == MovingStatus.GoingToTavern)
        {
            ArrivedAt(tavernPosition);
        }
        if (movingStatus == MovingStatus.GoingToCastle)
        {
            ArrivedAt(castlePosition);
        }
        if (decisionManager.GetDecision(DecisionManager.Decision.ReussirQuete1) &&
            !decisionManager.GetDecision(DecisionManager.Decision.AcheverQuete1) &&
            leaveRiver)
        {
            TPAtTavern();
            leaveRiver = false;
        }
    }
}
