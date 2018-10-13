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
    [SerializeField]
    private int initFoodStorage = 100;
    [SerializeField]
    private int initFoodUpkeep = 30;
    [SerializeField]
    private int initFoodProduction = 20;
    //Gold 
    [SerializeField]
    private int initGoldStorage = 100;
    [SerializeField]
    private int initGoldUpkeep = 20;
    [SerializeField]
    private int initGoldProduction = 30;
    //Exotic Goods
    [SerializeField]
    private int initEGStorage = 100;
    [SerializeField]
    private int initEGUpkeep = 10;
    [SerializeField]
    private int initEGProduction = 40;

    //values in game 
    //Food
    public int runtimeFoodStorage;
    public int runtimeFoodUpkeep;
    public int runtimeFoodProduction;
    //Gold
    public int runtimeGoldStorage;
    public int runtimeGoldUpkeep;
    public int runtimeGoldProduction;
    //EG
    public int runtimeEGStorage;
    public int runtimeEGUpkeep;
    public int runtimeEGProduction;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        //Food
        runtimeFoodStorage = initFoodStorage;
        runtimeFoodUpkeep = initFoodUpkeep;
        runtimeFoodProduction = initFoodProduction;
        //Gold
        runtimeGoldStorage = initGoldStorage;
        runtimeGoldUpkeep = initGoldUpkeep;
        runtimeGoldProduction = initGoldProduction;
        //Exotic Goods
        runtimeEGStorage = initEGStorage;
        runtimeEGUpkeep = initEGUpkeep;
        runtimeEGProduction = initEGProduction;
    }

    // computes how much of each resource remains after a day
    public void processResource()
    {
        runtimeFoodStorage = runtimeFoodStorage + runtimeFoodProduction - runtimeFoodUpkeep;
        runtimeGoldStorage = runtimeGoldStorage + runtimeGoldProduction - runtimeGoldUpkeep;
        runtimeEGStorage = runtimeEGStorage + runtimeEGProduction - runtimeEGUpkeep;
    }

}
