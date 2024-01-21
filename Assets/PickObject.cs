using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    public DecisionManager.Decision decision;
    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        Cursor.visible = true;
        
        if (Input.GetMouseButtonDown(0))
        {
            decisionManager.SetDecisionToTrue(decision);
            gameObject.SetActive(false);
        }
    }
}
