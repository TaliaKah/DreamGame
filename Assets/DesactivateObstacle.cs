using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateObstacle : MonoBehaviour
{
    void Update()
    {
        if (DecisionManager.Instance.GetDecision(DecisionManager.Decision.AccepterDeDevenirChevalier)
        || DecisionManager.Instance.GetDecision(DecisionManager.Decision.AccepterDeRejoindreLaRebellion))
        {
            gameObject.SetActive(false);
        }
    }
}
