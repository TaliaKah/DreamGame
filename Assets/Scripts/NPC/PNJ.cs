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
            transform.LookAt(playerTransform);
        }
    }
}
