using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int initFoodUpkeep = 0;
    [SerializeField]
    private int initFoodProduction = 10;
    [SerializeField]
    private int initFoodMilitaryGained = 0;
    //Gold
    [Header("Gold")]
    [SerializeField]
    private int initGoldStorage = 100;
    [SerializeField]
    private int initGoldUpkeep = 0;
    [SerializeField]
    private int initGoldProduction = 5;
    [SerializeField]
    private int initGoldMilitaryGained = 0;
    //Exotic Goods
    [Header("Exotic")]
    [SerializeField]
    private int initEGStorage = 100;
    [SerializeField]
    private int initEGUpkeep = 0;
    [SerializeField]
    private int initEGProduction = 5;
    [SerializeField]
    private int initEGMilitaryGained = 0;
    //Happiness 
    [SerializeField]
    private int initHappiness = 100;
    //json file input and ouput
    [SerializeField]
    private string filepathin;
    [SerializeField]
    private string filepathout;
    [Header("Health")]
    [SerializeField]
    private int Health;

    //values in game 
    [Space(3)]
    [Header("Runtime Values [No Touchy]")]
    //Food
    [Header("Food")]
    public int runtimeFoodStorage;
    public int runtimeFoodUpkeep;
    public int runtimeFoodProduction;
    public int runtimeFoodMiliaryGained;
    //Gold
    [Header("Gold")]
    public int runtimeGoldStorage;
    public int runtimeGoldUpkeep;
    public int runtimeGoldProduction;
    public int runtimeGoldMiliaryGained;
    //EG
    [Header("Exotic Goods")]
    public int runtimeEGStorage;
    public int runtimeEGUpkeep;
    public int runtimeEGProduction;
    public int runtimeEGMiliaryGained;
    //Happiness
    [Header("Happiness")]
    public int runtimeHappiness;
    // NPCandLordHolder
    [SerializeField]
    public NPCandLordHolder nPCandLordHolder;

    [Header("Boost Values")]
    public TechTree merchantTech;
    public TechTree farmTech;

    public StructureManager merchantStruct;
    public StructureManager farmStruct;
    public StructureManager productionStruct;
    public StructureManager scienceStruct;

    public int runtimeHealth;
    private int industryleadersUnhappy;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        //Food
        runtimeFoodStorage = initFoodStorage;
        runtimeFoodUpkeep = initFoodUpkeep;
        runtimeFoodProduction = initFoodProduction;
        runtimeFoodMiliaryGained = initFoodMilitaryGained;
        //Gold
        runtimeGoldStorage = initGoldStorage;
        runtimeGoldUpkeep = initGoldUpkeep;
        runtimeGoldProduction = initGoldProduction;
        runtimeGoldMiliaryGained = initGoldMilitaryGained;
        //Exotic Goods
        runtimeEGStorage = initEGStorage;
        runtimeEGUpkeep = initEGUpkeep;
        runtimeEGProduction = initEGProduction;
        runtimeEGMiliaryGained = initEGMilitaryGained;
        //Happiness
        runtimeHappiness = initHappiness;
        //Health
        runtimeHealth = Health;

    }

    // computes how much of each resource remains after a day
    public void processDailyActivities()
    {
        nPCandLordHolder.doDailyActions();
        // calculate total food, gold and EG produced
        
        int totalFoodProduced = (int)((nPCandLordHolder.AllyFarmer.WorkEfficiency/100) * runtimeFoodProduction + runtimeFoodMiliaryGained + farmTech.totalBoost + farmStruct.totalBoost);
        int totalGoldProduced = (int)((nPCandLordHolder.AllyMerchant.WorkEfficiency/100) * runtimeGoldProduction + runtimeGoldMiliaryGained + merchantTech.totalBoost + merchantStruct.totalBoost);
        int totalEGProduced = (int)((nPCandLordHolder.AllyMerchant.WorkEfficiency/100) * runtimeEGProduction + runtimeEGMiliaryGained + farmStruct.totalBoost + merchantStruct.totalBoost + productionStruct.totalBoost + scienceStruct.totalBoost);
        // Factor in the production and upkeep to get new storage amounts 
        runtimeFoodStorage = runtimeFoodStorage + totalFoodProduced - runtimeFoodUpkeep;
        runtimeGoldStorage = runtimeGoldStorage + totalGoldProduced - runtimeGoldUpkeep;
        runtimeEGStorage = runtimeEGStorage + totalEGProduced - runtimeEGUpkeep;

        nPCandLordHolder.allyIndustryCityHappinessModifiers();

        // make the dialog for the spymaster with template and updated resource and npc values
        // make the dialog for the spymaster with template and updated resource and npc values
        string stringfromSpymasterTemplate = File.ReadAllText(filepathin);
        //change gold values
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GoldUpkeep>>", runtimeGoldUpkeep.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GoldProduction>>", runtimeGoldProduction.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GoldStorage>>", runtimeGoldStorage.ToString());
        //change food values
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FoodUpkeep>>", runtimeFoodUpkeep.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FoodProduction>>", runtimeFoodProduction.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FoodStorage>>", runtimeFoodStorage.ToString());
        //change exotic values 
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ExoticGoodsUpkeep>>",runtimeEGUpkeep.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ExoticGoodsProduction>>", runtimeEGProduction.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ExoticGoodsStorage>>", runtimeEGStorage.ToString());
        // change allyindustryleaders happiness levels
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<MerchantHappiness>>", nPCandLordHolder.AllyMerchant.Happiness.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<BuilderHappiness>>", nPCandLordHolder.AllyBuilder.Happiness.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GeneralHappiness>>", nPCandLordHolder.AllyGeneral.Happiness.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FarmerHappiness>>", nPCandLordHolder.AllyFarmer.Happiness.ToString());
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ScholarHappiness>>", nPCandLordHolder.AllyScholar.Happiness.ToString());
        // Get the work efficinecy of each ally industry leader
        int merchantPredictedWorkEfficiency = (int)nPCandLordHolder.AllyMerchant.WorkEfficiency + Random.Range(-5, 5);
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<MerchantEfficiency>>", merchantPredictedWorkEfficiency.ToString());

        int builderPredictedWorkEfficiency = (int)nPCandLordHolder.AllyBuilder.WorkEfficiency + Random.Range(-5, 5);
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<BuilderEfficiency>>", builderPredictedWorkEfficiency.ToString());

        int generalPredictedWorkEfficiency = (int)nPCandLordHolder.AllyGeneral.WorkEfficiency + Random.Range(-5, 5);
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GeneralEfficiency>>", generalPredictedWorkEfficiency.ToString());

        int farmerPredictedWorkEfficiency = (int)nPCandLordHolder.AllyFarmer.WorkEfficiency + Random.Range(-5, 5);
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FarmerEfficiency>>", farmerPredictedWorkEfficiency.ToString());

        int scholarPredictedWorkEfficiency = (int)nPCandLordHolder.AllyScholar.WorkEfficiency + Random.Range(-5, 5);
        stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ScholarEfficiency>>", scholarPredictedWorkEfficiency.ToString());

        using (var stream = new FileStream(filepathout, FileMode.Truncate))
        {
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(stringfromSpymasterTemplate);
                writer.Close();
            }
        }

        AssetDatabase.Refresh();

        // see if the game had ended yet
        // City is destroyed
        if (runtimeHealth <= 0)
        {
            GameObject GO = GameObject.Find("GameManager");
            GameManager GM = GO.GetComponent<GameManager>();
            GM.Ending = "Lose1.png";
            SceneManager.LoadScene("Assets/Scenes/UIScenes/Game Over.unity");
        }

        // see if the whole city would riot
        // see how many people are unhappy and not fearful
        int peopleRiotAmount = 0;
        if (nPCandLordHolder.AllyBuilder.Happiness <= 25 && nPCandLordHolder.AllyBuilder.Fearfulness <= 25)
        {
            peopleRiotAmount++;
        }
        if (nPCandLordHolder.AllyMerchant.Happiness <= 25 && nPCandLordHolder.AllyMerchant.Fearfulness <= 25)
        {
            peopleRiotAmount++;
        }
        if (nPCandLordHolder.AllyScholar.Happiness <= 25 && nPCandLordHolder.AllyScholar.Fearfulness <= 25)
        {
            peopleRiotAmount++;
        }
        if (nPCandLordHolder.AllyFarmer.Happiness <= 25 && nPCandLordHolder.AllyFarmer.Fearfulness <= 25)
        {
            peopleRiotAmount++;
        }
        if (nPCandLordHolder.AllyGeneral.Happiness <= 25 && nPCandLordHolder.AllyGeneral.Fearfulness <= 25)
        {
            peopleRiotAmount++;
        }

        // see if anyone had rebelled yet
        bool leadersRebelling = false;
        if (nPCandLordHolder.AllyBuilder.Rebelling || nPCandLordHolder.AllyFarmer.Rebelling || nPCandLordHolder.AllyGeneral.Rebelling|| nPCandLordHolder.AllyMerchant.Rebelling || nPCandLordHolder.AllyScholar.Rebelling)
        {
            leadersRebelling = true;
        }
        // if all 5 members are in riot range and one of them riots, game over
        if (leadersRebelling && peopleRiotAmount == 5)
        {
            GameObject GO = GameObject.Find("GameManager");
            GameManager GM = GO.GetComponent<GameManager>();
            GM.Ending = "oustedbythepeoplebadending";
            SceneManager.LoadScene("Assets/Scenes/UIScenes/Game Over.unity");
        }
    }

}
