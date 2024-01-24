using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTracker : MonoBehaviour
{
    private static DecisionTracker _instance;
    public static DecisionTracker Instance => _instance;

    private Dictionary<DecisionManager.Decision, bool> _decisions = new ();
    public Dictionary<DecisionManager.Decision, bool> Decisions => _decisions;

    private void Awake() {
        if (_instance is null) {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
