using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCandLordHolder", menuName = "Ministrare/SingletonVars/NPCandLordHolder", order = 3)]
public class NPCandLordHolder : ScriptableObject {

    // Allies
    public IndustryLeader AllyFarmer;
    public IndustryLeader AllyGeneral;
    public IndustryLeader AllyScholar;
    public IndustryLeader AllyMerchant;
    public IndustryLeader AllyBuilder;
    // Enemy
    public IndustryLeader EnemyFarmer;
    public IndustryLeader EnemyGeneral;
    public IndustryLeader EnemyScholar;
    public IndustryLeader EnemyMerchant;
    public IndustryLeader EnemyBuilder;
    // our character (Lord)
    public Lord Lord;
    // leader of other city
    public Lord EnemyLord;

   public void OnEnable()
   {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    public void Initialize()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        //Ally IndustryLeaders Initialization
        AllyFarmer = new IndustryLeader();
        AllyGeneral = new IndustryLeader();
        AllyScholar = new IndustryLeader();
        AllyMerchant = new IndustryLeader();
        AllyBuilder = new IndustryLeader();

        // our character Initialization
        Lord = new Lord();

        //Enemy IndustryLeaders Initialization
        EnemyFarmer = new IndustryLeader();
        EnemyGeneral = new IndustryLeader();
        EnemyScholar = new IndustryLeader();
        EnemyMerchant = new IndustryLeader();
        EnemyBuilder = new IndustryLeader();

        // enemy Leader Initialization
        EnemyLord = new Lord();
    }

    public void doDailyworkEffeciency()
    {
        AllyBuilder.generateWorkEfficiency();
        AllyFarmer.generateWorkEfficiency();
        AllyGeneral.generateWorkEfficiency();
        AllyMerchant.generateWorkEfficiency();
        AllyScholar.generateWorkEfficiency();
        EnemyBuilder.generateWorkEfficiency();
        EnemyFarmer.generateWorkEfficiency();
        EnemyGeneral.generateWorkEfficiency();
        EnemyMerchant.generateWorkEfficiency();
        EnemyScholar.generateWorkEfficiency();
    }

    public void doDailyMoodChange()
    {
        AllyBuilder.dailyMoodChange();
        AllyFarmer.dailyMoodChange();
        AllyGeneral.dailyMoodChange();
        AllyMerchant.dailyMoodChange();
        AllyScholar.dailyMoodChange();
        EnemyBuilder.dailyMoodChange();
        EnemyFarmer.dailyMoodChange();
        EnemyGeneral.dailyMoodChange();
        EnemyMerchant.dailyMoodChange();
        EnemyScholar.dailyMoodChange();
    }
}
