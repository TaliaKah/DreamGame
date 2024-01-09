using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateObstacle : MonoBehaviour
{
    void Update()
    {
    DecisionManager decisionManager = FindObjectOfType<DecisionManager>();

    if (decisionManager != null &&
        (decisionManager.GetDecision(DecisionManager.Decision.RencontrerLesChevaliersDansLaPlaine)))
        {
            gameObject.SetActive(false);
            Debug.Log("Objet désactivé !");
        }
    }
}
