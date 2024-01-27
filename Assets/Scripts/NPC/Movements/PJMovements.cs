using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJMovements : MonoBehaviour
{
    public GameObject prison;
   
    public void GoingToJail()
    {
        transform.position = prison.transform.position;
        Debug.Log($"{transform.name} is going to jail");
    }
}
