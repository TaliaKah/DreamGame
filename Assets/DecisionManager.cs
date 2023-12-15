using UnityEngine;
using System;
using System.Collections.Generic;

public class DecisionManager : MonoBehaviour
{
    private static DecisionManager _instance;
    public static DecisionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("DecisionManager").AddComponent<DecisionManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    public enum Decision
    {
        AccepterDeDevenirChevalier,
        AccepterDeRejoindreLaRebellion,
        RefuserDeRejoindreLaRebellion
    }

    private Dictionary<Decision, bool> _decisions;

    private DecisionManager()
    {
        _decisions = new Dictionary<Decision, bool>();
        InitializeDecisions();
    }

    private void InitializeDecisions()
    {
        foreach (Decision decision in Enum.GetValues(typeof(Decision)))
        {
            _decisions.Add(decision, false);
        }
    }

    public bool GetDecision(Decision decision)
    {
        if (_decisions.ContainsKey(decision))
        {
            return _decisions[decision];
        }
        else
        {
            UnityEngine.Debug.LogWarning($"La décision {decision} n'existe pas dans le dictionnaire.");
            return false;
        }
    }

    public void SetDecision(Decision decision, bool value)
    {
        if (_decisions.ContainsKey(decision))
        {
            _decisions[decision] = value;
        }
        else
        {
            UnityEngine.Debug.LogWarning($"La décision {decision} n'existe pas dans le dictionnaire.");
        }
    }
}
