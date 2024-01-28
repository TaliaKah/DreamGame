using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateObstacle : MonoBehaviour
{
    public DecisionManager.Decision decision;
    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    void Update()
    {
        if (decisionManager != null &&
            (decisionManager.GetDecision(decision)))
        {
            gameObject.SetActive(false);
        }
    }
}
