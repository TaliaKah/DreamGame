using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    public string PNJName;

    public string description;

    public Transform playerTransform;

    public void LookAtUs()
    {
        if (playerTransform != null)
        {
            Vector3 directionToLook = playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToLook);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
