using UnityEngine;
using System.Collections.Generic;

public class DecisionManager : MonoBehaviour
{
    public enum Decision
    {
        MechantIntro,
        RencontrerLesChevaliersDansLaPlaine,
        SurprendreLesFees,
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
        TrouverPoudreDEscampette,
        SeReveiller
    }

    private DecisionTracker _decisionTracker;
    public Dictionary<Decision, bool> Decisions => _decisionTracker.Decisions;

    private void Start()
    {
        _decisionTracker = DecisionTracker.Instance;
    }

    public bool GetDecision(Decision decision)
    {
        if (Decisions.ContainsKey(decision))
        {
            return Decisions[decision];
        }
        else
        {
            UnityEngine.Debug.LogWarning($"La décision {decision} n'existe pas dans le dictionnaire.");
            return false;
        }
    }

    public void SetDecisionToTrue(Decision decision)
    {
        if (Decisions.ContainsKey(decision))
        {
            Decisions[decision] = true;
        }
        else
        {
            UnityEngine.Debug.LogWarning($"La décision {decision} n'existe pas dans le dictionnaire.");
        }
    }

    public void SetDecision(Decision decision, bool value)
    {
        if (Decisions.ContainsKey(decision))
        {
            Decisions[decision] = value;
            Debug.Log($"La décision {decision} est mainetnant {value}");
        }
        else
        {
            UnityEngine.Debug.LogWarning($"La décision {decision} n'existe pas dans le dictionnaire.");
        }
    }

    public void MechantIntro()
    {
        Decisions[Decision.MechantIntro] = true;
        Debug.LogWarning($"{Decision.MechantIntro} est {Decisions[Decision.MechantIntro]}");
    }

    public void RencontrerLesChevaliersDansLaPlaine()
    {
        Decisions[Decision.RencontrerLesChevaliersDansLaPlaine] = true;
        Debug.LogWarning($"{Decision.RencontrerLesChevaliersDansLaPlaine} est {Decisions[Decision.RencontrerLesChevaliersDansLaPlaine]}");
    }

    public void SurprendreLesFees()
    {
        Decisions[Decision.SurprendreLesFees] = true;
        Debug.LogWarning($"{Decision.SurprendreLesFees} est {Decisions[Decision.SurprendreLesFees]}");
    }

    public void AccepterDeDevenirChevalier()
    {
        Decisions[Decision.AccepterDeDevenirChevalier] = true;
        Debug.LogWarning($"{Decision.AccepterDeDevenirChevalier} est {Decisions[Decision.AccepterDeDevenirChevalier]}");
    }
    
    public void AccepterDeRejoindreLaRebellion()
    {
        Decisions[Decision.AccepterDeRejoindreLaRebellion] = true;
        Debug.LogWarning($"{Decision.AccepterDeRejoindreLaRebellion} est {Decisions[Decision.AccepterDeRejoindreLaRebellion]}");
    }
    
    public void RefuserDeRejoindreLaRebellion()
    {
        Decisions[Decision.RefuserDeRejoindreLaRebellion] = true;
        Debug.LogWarning($"{Decision.RefuserDeRejoindreLaRebellion} est {Decisions[Decision.RefuserDeRejoindreLaRebellion]}");
    }
    
    public void RencontrerLeTavernier()
    {
        Decisions[Decision.RencontrerLeTavernier] = true;
        Debug.LogWarning($"{Decision.RencontrerLeTavernier} est {Decisions[Decision.RencontrerLeTavernier]}");
    }
    
    public void AllerEnPrison()
    {
        Decisions[Decision.AllerEnPrison] = true;
        Debug.LogWarning($"{Decision.AllerEnPrison} est {Decisions[Decision.AllerEnPrison]}");
    }

    public void RencontrerSorciere()
    {
        Decisions[Decision.RencontrerSorciere] = true;
        Debug.LogWarning($"{Decision.RencontrerSorciere} est {Decisions[Decision.RencontrerSorciere]}");
    }

    public void RechercherQuete1()
    {
        Decisions[Decision.RechercherQuete1] = true;
        Debug.LogWarning($"{Decision.RechercherQuete1} est {Decisions[Decision.RechercherQuete1]}");
    }

    public void DebuterQuete1()
    {
        Decisions[Decision.DebuterQuete1] = true;
        Debug.LogWarning($"{Decision.DebuterQuete1} est {Decisions[Decision.DebuterQuete1]}");
    }

    public void ReussirQuete1()
    {
        Decisions[Decision.ReussirQuete1] = true;
        Debug.LogWarning($"{Decision.ReussirQuete1} est {Decisions[Decision.ReussirQuete1]}");
    }
    
    public void AcheverQuete1()
    {
        Decisions[Decision.AcheverQuete1] = true;
        Debug.LogWarning($"{Decision.AcheverQuete1} est {Decisions[Decision.AcheverQuete1]}");
    }

    public void DebuterQuete2()
    {
        Decisions[Decision.DebuterQuete2] = true;
        Debug.LogWarning($"{Decision.DebuterQuete2} est {Decisions[Decision.DebuterQuete2]}");
    }

    public void ReussirQuete2()
    {
        Decisions[Decision.ReussirQuete2] = true;
        Debug.LogWarning($"{Decision.ReussirQuete2} est {Decisions[Decision.ReussirQuete2]}");
    }

    public void AcheverQuete2()
    {
        Decisions[Decision.AcheverQuete2] = true;
        Debug.LogWarning($"{Decision.AcheverQuete2} est {Decisions[Decision.AcheverQuete2]}");
    }

    public void DebuterQuete3()
    {
        Decisions[Decision.DebuterQuete3] = true;
        Debug.LogWarning($"{Decision.DebuterQuete3} est {Decisions[Decision.DebuterQuete3]}");
    }

    public void ReussirQuete3()
    {
        Decisions[Decision.ReussirQuete3] = true;
        Debug.LogWarning($"{Decision.ReussirQuete3} est {Decisions[Decision.ReussirQuete3]}");
    }
    
    public void AcheverQuete3()
    {
        Decisions[Decision.AcheverQuete3] = true;
        Debug.LogWarning($"{Decision.AcheverQuete3} est {Decisions[Decision.AcheverQuete3]}");
    }
    
    public void RechercherLaPotionDEveil()
    {
        Decisions[Decision.RechercherLaPotionDEveil] = true;
        Debug.LogWarning($"{Decision.RechercherLaPotionDEveil} est {Decisions[Decision.RechercherLaPotionDEveil]}");
    }
        
    public void AllerALaMontagneDuDesespoir()
    {
        Decisions[Decision.AllerALaMontagneDuDesespoir] = true;
        Debug.LogWarning($"{Decision.AllerALaMontagneDuDesespoir} est {Decisions[Decision.AllerALaMontagneDuDesespoir]}");
    }
            
                
    public void RencontrerSphynx()
    {
        Decisions[Decision.RencontrerSphynx] = true;
        Debug.LogWarning($"{Decision.RencontrerSphynx} est {Decisions[Decision.RencontrerSphynx]}");
    }
                
    public void TrouverLeCube()
    {
        Decisions[Decision.TrouverLeCube] = true;
        Debug.LogWarning($"{Decision.TrouverLeCube} est {Decisions[Decision.TrouverLeCube]}");
    }
                
    public void TrouverLaPotionDEveil()
    {
        Decisions[Decision.TrouverLaPotionDEveil] = true;
        Debug.LogWarning($"{Decision.TrouverLaPotionDEveil} est {Decisions[Decision.TrouverLaPotionDEveil]}");
    }

    public void AllerAuChateau()
    {
        Decisions[Decision.AllerAuChateau] = true;
        Debug.LogWarning($"{Decision.AllerAuChateau} est {Decisions[Decision.AllerAuChateau]}");
    }  
    
    public void TaperMechant()
    {
        Decisions[Decision.TaperMechant] = true;
        Debug.LogWarning($"{Decision.TaperMechant} est {Decisions[Decision.TaperMechant]}");
    }  

    public void TaperFee()
    {
        Decisions[Decision.TaperFee] = true;
        Debug.LogWarning($"{Decision.TaperFee} est {Decisions[Decision.TaperFee]}");
    }    

    public void SeReveiller()
    {
        Decisions[Decision.SeReveiller] = true;
        Debug.LogWarning($"{Decision.SeReveiller} est {Decisions[Decision.SeReveiller]}");
    }         
}
