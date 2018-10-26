using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpyMaster : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private ResourceManager resourceManager;

    void Start () {
        //On start, update text to current, correct info
        //Food
        Text FoodStorageText = GameObject.Find("FoodStorageText").GetComponent<Text>();
        FoodStorageText.text = "Food Storage: " + resourceManager.runtimeFoodStorage;
        Text FoodProductionText = GameObject.Find("FoodProductionText").GetComponent<Text>();
        FoodProductionText.text = "Food Production: " + resourceManager.runtimeFoodProduction;
        Text FoodUpkeepText = GameObject.Find("FoodUpkeepText").GetComponent<Text>();
        FoodUpkeepText.text = "Food Upkeep " + resourceManager.runtimeFoodUpkeep;
        //Gold
        Text GoldStorageText = GameObject.Find("GoldStorageText").GetComponent<Text>();
        GoldStorageText.text = "Gold Storage: " + resourceManager.runtimeGoldStorage;
        Text GoldProductionText = GameObject.Find("GoldProductionText").GetComponent<Text>();
        GoldProductionText.text = "Gold Production: " + resourceManager.runtimeGoldProduction;
        Text GoldUpkeepText = GameObject.Find("GoldUpkeepText").GetComponent<Text>();
        GoldUpkeepText.text = "Gold Upkeep: " + resourceManager.runtimeGoldUpkeep;
        //Exotic Goods
        Text EGStorageText = GameObject.Find("EGStorageText").GetComponent<Text>();
        EGStorageText.text = "Exotic Goods Storage: " + resourceManager.runtimeEGStorage;
        Text EGProductionText = GameObject.Find("EGProductionText").GetComponent<Text>();
        EGProductionText.text = "Exotic Goods Production: " + resourceManager.runtimeEGProduction;
        Text EGUpkeepText = GameObject.Find("EGUpkeepText").GetComponent<Text>();
        EGUpkeepText.text = "Exotic Goods Upkeep: " + resourceManager.runtimeEGUpkeep;
        //Happiness
        Text HappinessText = GameObject.Find("Happiness").GetComponent<Text>();
        HappinessText.text = "Happiness: " + resourceManager.runtimeHappiness;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
