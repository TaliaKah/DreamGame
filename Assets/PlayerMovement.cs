using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

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

        // Déclencher la destination lors d'un clic de souris
        if (Input.GetMouseButtonDown(0))
        {
            SetDestinationToMousePosition();
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        navMeshAgent.Move(direction * Time.deltaTime * navMeshAgent.speed);
    }

    void SetDestinationToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            navMeshAgent.SetDestination(hit.point);
        }
    }
}
