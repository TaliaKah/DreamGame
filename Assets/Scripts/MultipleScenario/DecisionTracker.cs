using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTracker : MonoSingleton<DecisionTracker>
{
    private Dictionary<DecisionManager.Decision, bool> _decisions = new ();
    public Dictionary<DecisionManager.Decision, bool> Decisions {
        get => _decisions; set => _decisions = value;
    }

    private void Start() {
        if (Instance == this) {
            Initialize();
        }
    }

    private void Initialize() {
        foreach (DecisionManager.Decision decision in Enum.GetValues(typeof(DecisionManager.Decision)))
        {
            _decisions.Add(decision, false);
            UnityEngine.Debug.Log($"{decision} est ajouté dans le dictionnaire avec la valeur {Decisions[decision]}");
        }
        UnityEngine.Debug.Log($"Les décisions ont été initialisées.");
    }
}
