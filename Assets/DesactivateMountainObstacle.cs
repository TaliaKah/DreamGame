using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivateMountainObstacle : MonoBehaviour
{
    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    void Update()
    {
        if (decisionManager != null &&
            (decisionManager.GetDecision(DecisionManager.Decision.AllerALaMontagneDuDesespoir)))
        {
            gameObject.SetActive(false);
            Debug.Log("Blocage de la montagne désactivé !");
        }
    }
}
