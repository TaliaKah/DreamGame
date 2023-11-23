using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target; // Référence au transform du personnage à suivre
    public Vector3 offset = new Vector3(0f, 5f, -5f); // Décalage de la caméra par rapport au personnage
    public float smoothSpeed = 0.125f; // Vitesse de suivi

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }
}