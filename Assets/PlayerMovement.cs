using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public GameObject corridor;

    public void ResetPosition()
    {
        transform.position = corridor.transform.position;
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Déplacement avec les touches Z, Q, S, D
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Déplacer le personnage
        MoveCharacter(movementInput);
    }

    void MoveCharacter(Vector3 direction)
    {
        navMeshAgent.Move(direction * Time.deltaTime * navMeshAgent.speed);
    }
}
