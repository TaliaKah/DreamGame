using UnityEngine;
using System;
using System.Collections.Generic;

public class DecisionManager : MonoBehaviour
{
    public enum Decision
    {
        AccepterDeDevenirChevalier,
        AccepterDeRejoindreLaRebellion,
        RefuserDeRejoindreLaRebellion,
        PrendreUneBoissonALaTaverne
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
            UnityEngine.Debug.Log($"{decision} est ajouté dans le dictionnaire avec la valeur {_decisions[decision]}");
        }
        UnityEngine.Debug.Log($"Les décisions ont été initialisées.");
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
            Debug.Log($"La décision {decision} est mainetnant {value}");
        }
        else
        {
            UnityEngine.Debug.LogWarning($"La décision {decision} n'existe pas dans le dictionnaire.");
        }
    }

    public void AccepterDeDevenirChevalier()
    {
        _decisions[Decision.AccepterDeDevenirChevalier] = true;
        Debug.LogWarning($"{Decision.AccepterDeDevenirChevalier} est {_decisions[Decision.AccepterDeDevenirChevalier]}");
    }
    
    public void AccepterDeRejoindreLaRebellion()
    {
        _decisions[Decision.AccepterDeRejoindreLaRebellion] = true;
        Debug.LogWarning($"{Decision.AccepterDeRejoindreLaRebellion} est {_decisions[Decision.AccepterDeRejoindreLaRebellion]}");
    }
    
    public void RefuserDeRejoindreLaRebellion()
    {
        _decisions[Decision.RefuserDeRejoindreLaRebellion] = true;
        Debug.LogWarning($"{Decision.RefuserDeRejoindreLaRebellion} est {_decisions[Decision.RefuserDeRejoindreLaRebellion]}");
    }
    
    public void PrendreUneBoissonALaTaverne()
    {
        _decisions[Decision.PrendreUneBoissonALaTaverne] = true;
        Debug.LogWarning($"{Decision.PrendreUneBoissonALaTaverne} est {_decisions[Decision.PrendreUneBoissonALaTaverne]}");
    }
}
