using UnityEngine;
using System;
using System.Collections.Generic;

public class DecisionManager : MonoBehaviour
{
    public enum Decision
    {
        RencontrerLesChevaliersDansLaPlaine,
        AccepterDeDevenirChevalier,
        AccepterDeRejoindreLaRebellion,
        RefuserDeRejoindreLaRebellion,
        RencontrerLeTavernier,
        AllerEnPrison,
        RencontrerSorciere,
        RechercherQuete1,
        DebuterQuete1,
        ReussirQuete1,
        AcheverQuete1,
        DebuterQuete2,
        ReussirQuete2,
        AcheverQuete2,
        DebuterQuete3,
        ReussirQuete3,
        AcheverQuete3,
        AllerALaMontagneDuDesespoir,
        RechercherLaPotionDEveil,
        RencontrerSphynx,
        TrouverLeCube,
        TrouverLaPotionDEveil,
        BoireLaPotionDEveil,
        AllerAuChateau,
        TrouverLaFleurDeVerite,
        TaperMechant,
        BattreMechant,
        TaperFee,
        BattreFee,
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

    public void RencontrerLesChevaliersDansLaPlaine()
    {
        _decisions[Decision.RencontrerLesChevaliersDansLaPlaine] = true;
        Debug.LogWarning($"{Decision.RencontrerLesChevaliersDansLaPlaine} est {_decisions[Decision.RencontrerLesChevaliersDansLaPlaine]}");
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
    
    public void RencontrerLeTavernier()
    {
        _decisions[Decision.RencontrerLeTavernier] = true;
        Debug.LogWarning($"{Decision.RencontrerLeTavernier} est {_decisions[Decision.RencontrerLeTavernier]}");
    }
    
    public void AllerEnPrison()
    {
        _decisions[Decision.AllerEnPrison] = true;
        Debug.LogWarning($"{Decision.AllerEnPrison} est {_decisions[Decision.AllerEnPrison]}");
    }

    public void RencontrerSorciere()
    {
        _decisions[Decision.RencontrerSorciere] = true;
        Debug.LogWarning($"{Decision.RencontrerSorciere} est {_decisions[Decision.RencontrerSorciere]}");
    }

    public void RechercherQuete1()
    {
        _decisions[Decision.RechercherQuete1] = true;
        Debug.LogWarning($"{Decision.RechercherQuete1} est {_decisions[Decision.RechercherQuete1]}");
    }

    public void DebuterQuete1()
    {
        _decisions[Decision.DebuterQuete1] = true;
        Debug.LogWarning($"{Decision.DebuterQuete1} est {_decisions[Decision.DebuterQuete1]}");
    }

    public void ReussirQuete1()
    {
        _decisions[Decision.ReussirQuete1] = true;
        Debug.LogWarning($"{Decision.ReussirQuete1} est {_decisions[Decision.ReussirQuete1]}");
    }
    
    public void AcheverQuete1()
    {
        _decisions[Decision.AcheverQuete1] = true;
        Debug.LogWarning($"{Decision.AcheverQuete1} est {_decisions[Decision.AcheverQuete1]}");
    }

    public void DebuterQuete2()
    {
        _decisions[Decision.DebuterQuete2] = true;
        Debug.LogWarning($"{Decision.DebuterQuete2} est {_decisions[Decision.DebuterQuete2]}");
    }

    public void ReussirQuete2()
    {
        _decisions[Decision.ReussirQuete2] = true;
        Debug.LogWarning($"{Decision.ReussirQuete2} est {_decisions[Decision.ReussirQuete2]}");
    }

    public void AcheverQuete2()
    {
        _decisions[Decision.AcheverQuete2] = true;
        Debug.LogWarning($"{Decision.AcheverQuete2} est {_decisions[Decision.AcheverQuete2]}");
    }

    public void DebuterQuete3()
    {
        _decisions[Decision.DebuterQuete3] = true;
        Debug.LogWarning($"{Decision.DebuterQuete3} est {_decisions[Decision.DebuterQuete3]}");
    }

    public void ReussirQuete3()
    {
        _decisions[Decision.ReussirQuete3] = true;
        Debug.LogWarning($"{Decision.ReussirQuete3} est {_decisions[Decision.ReussirQuete3]}");
    }
    
    public void AcheverQuete3()
    {
        _decisions[Decision.AcheverQuete3] = true;
        Debug.LogWarning($"{Decision.AcheverQuete3} est {_decisions[Decision.AcheverQuete3]}");
    }
    
    public void RechercherLaPotionDEveil()
    {
        _decisions[Decision.RechercherLaPotionDEveil] = true;
        Debug.LogWarning($"{Decision.RechercherLaPotionDEveil} est {_decisions[Decision.RechercherLaPotionDEveil]}");
    }
        
    public void AllerALaMontagneDuDesespoir()
    {
        _decisions[Decision.AllerALaMontagneDuDesespoir] = true;
        Debug.LogWarning($"{Decision.AllerALaMontagneDuDesespoir} est {_decisions[Decision.AllerALaMontagneDuDesespoir]}");
    }
            
                
    public void RencontrerSphynx()
    {
        _decisions[Decision.RencontrerSphynx] = true;
        Debug.LogWarning($"{Decision.RencontrerSphynx} est {_decisions[Decision.RencontrerSphynx]}");
    }
                
    public void TrouverLeCube()
    {
        _decisions[Decision.TrouverLeCube] = true;
        Debug.LogWarning($"{Decision.TrouverLeCube} est {_decisions[Decision.TrouverLeCube]}");
    }
                
    public void TrouverLaPotionDEveil()
    {
        _decisions[Decision.TrouverLaPotionDEveil] = true;
        Debug.LogWarning($"{Decision.TrouverLaPotionDEveil} est {_decisions[Decision.TrouverLaPotionDEveil]}");
    }

    public void AllerAuChateau()
    {
        _decisions[Decision.AllerAuChateau] = true;
        Debug.LogWarning($"{Decision.AllerAuChateau} est {_decisions[Decision.AllerAuChateau]}");
    }  
    
    public void TaperMechant()
    {
        _decisions[Decision.TaperMechant] = true;
        Debug.LogWarning($"{Decision.TaperMechant} est {_decisions[Decision.TaperMechant]}");
    }  

    public void TaperFee()
    {
        _decisions[Decision.TaperFee] = true;
        Debug.LogWarning($"{Decision.TaperFee} est {_decisions[Decision.TaperFee]}");
    }           
}
