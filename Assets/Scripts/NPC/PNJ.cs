using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    public string PNJName;

    public string description;

    public Transform playerTransform;
    
    public float rotationSpeed = 5.0f; 

    public void LookAtUs()
    {
        if (playerTransform != null)
        {
            Vector3 directionToLook = playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToLook);

            transform.rotation = targetRotation;
        }
    }
}
