using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateObstacle : MonoBehaviour
{
    void Update()
    {
    DecisionManager decisionManager = FindObjectOfType<DecisionManager>(); // Utilisez cette ligne si DecisionManager est attaché à un objet dans la scène.

    if (decisionManager != null &&
        (decisionManager.GetDecision(DecisionManager.Decision.AccepterDeDevenirChevalier) ||
         decisionManager.GetDecision(DecisionManager.Decision.AccepterDeRejoindreLaRebellion)))
        {
            gameObject.SetActive(false);
        }
    }
}
