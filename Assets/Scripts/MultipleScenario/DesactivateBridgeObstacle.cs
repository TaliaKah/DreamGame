using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateBrigdeObstacle : MonoBehaviour
{
    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    void Update()
    {
        if (decisionManager != null &&
            ((decisionManager.GetDecision(DecisionManager.Decision.AllerAuChateau)) || decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison)))
        {
            gameObject.SetActive(false);
            Debug.Log("Obstacle des ponts désactivé !");
        }
    }
}
