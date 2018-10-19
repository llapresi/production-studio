using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceManager", menuName = "Ministrare/SingletonVars/ResourceManager", order = 2)]
public class ResourceManager : ScriptableObject {
    //This will hold the resources that will be used by research, building units etc.
    //It will be able to connect to Clock and manage resouces upkeep and production
    //This will also be the place to say how much we lose and gain

    //Starting values
    //Food
    [Header("Food")]
    [SerializeField]
    private int initFoodStorage = 100;
    [SerializeField]
    private int initFoodUpkeep = 30;
    [SerializeField]
    private int initFoodProduction = 20;
    [SerializeField]
    private double initFoodHappinessEfficiency = 1;
    [SerializeField]
    private int initFoodMilitaryGained = 0;
    //Gold
    [Header("Gold")]
    [SerializeField]
    private int initGoldStorage = 100;
    [SerializeField]
    private int initGoldUpkeep = 20;
    [SerializeField]
    private int initGoldProduction = 30;
    [SerializeField]
    private double initGoldHappinessEfficiency = 1;
    [SerializeField]
    private int initGoldMilitaryGained = 0;
    //Exotic Goods
    [Header("Exotic")]
    [SerializeField]
    private int initEGStorage = 100;
    [SerializeField]
    private int initEGUpkeep = 10;
    [SerializeField]
    private int initEGProduction = 40;
    [SerializeField]
    private double initEGHappinessEfficiency = 1;
    [SerializeField]
    private int initEGMilitaryGained = 0;
    //Happiness 
    [SerializeField]
    private int initHappiness = 100;
    

    //values in game 
    [Space(3)]
    [Header("Runtime Values [No Touchy]")]
    //Food
    [Header("Food")]
    public int runtimeFoodStorage;
    public int runtimeFoodUpkeep;
    public int runtimeFoodProduction;
    public double runtimeFoodHappinessEfficiency;
    public int runtimeFoodMiliaryGained;
    //Gold
    [Header("Gold")]
    public int runtimeGoldStorage;
    public int runtimeGoldUpkeep;
    public int runtimeGoldProduction;
    public double runtimeGoldHappinessEfficiency;
    public int runtimeGoldMiliaryGained;
    //EG
    [Header("Exotic Goods")]
    public int runtimeEGStorage;
    public int runtimeEGUpkeep;
    public int runtimeEGProduction;
    public double runtimeEGHappinessEfficiency;
    public int runtimeEGMiliaryGained;
    //Happiness
    [Header("Happiness")]
    public int runtimeHappiness;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        //Food
        runtimeFoodStorage = initFoodStorage;
        runtimeFoodUpkeep = initFoodUpkeep;
        runtimeFoodProduction = initFoodProduction;
        runtimeFoodHappinessEfficiency = initFoodHappinessEfficiency;
        runtimeFoodMiliaryGained = initFoodMilitaryGained;
        //Gold
        runtimeGoldStorage = initGoldStorage;
        runtimeGoldUpkeep = initGoldUpkeep;
        runtimeGoldProduction = initGoldProduction;
        runtimeGoldHappinessEfficiency = initGoldHappinessEfficiency;
        runtimeGoldMiliaryGained = initGoldMilitaryGained;
        //Exotic Goods
        runtimeEGStorage = initEGStorage;
        runtimeEGUpkeep = initEGUpkeep;
        runtimeEGProduction = initEGProduction;
        runtimeEGHappinessEfficiency = initEGHappinessEfficiency;
        runtimeEGMiliaryGained = initEGMilitaryGained;
        //Happiness
        runtimeHappiness = initHappiness;
    }

    // computes how much of each resource remains after a day
    public void processResource()
    {
        // calculate total food, gold and EG produced
        int totalFoodProduced = (int)(runtimeFoodHappinessEfficiency * runtimeFoodProduction + runtimeFoodMiliaryGained);
        int totalGoldProduced = (int)(runtimeGoldHappinessEfficiency * runtimeGoldProduction + runtimeGoldMiliaryGained);
        int totalEGProduced = (int)(runtimeEGHappinessEfficiency * runtimeEGProduction + runtimeEGMiliaryGained);
        // Factor in the production and upkeep to get new storage amounts 
        runtimeFoodStorage = runtimeFoodStorage + totalFoodProduced - runtimeFoodUpkeep;
        runtimeGoldStorage = runtimeGoldStorage + totalGoldProduced - runtimeGoldUpkeep;
        runtimeEGStorage = runtimeEGStorage + totalEGProduced - runtimeEGUpkeep;
    }

}
