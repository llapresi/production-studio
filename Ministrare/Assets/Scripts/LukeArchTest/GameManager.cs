using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool hasStarted = false;
    [SerializeField]
    private NPCandLordHolder NPCLordHolder;
    [SerializeField]
    private ResourceManager resourceManager;
    [SerializeField]
    private string filepathin;
    [SerializeField]
    private string filepathout;
    // Use this for initialization
    void Start()
    {
        if (hasStarted == false)
        {
            NPCLordHolder.Initialize();
            hasStarted = true;

            // make the dialog for the spymaster with template and updated resource and npc values
            string stringfromSpymasterTemplate = File.ReadAllText(filepathin);
            //change gold values
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GoldUpkeep>>", resourceManager.runtimeGoldUpkeep.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GoldProduction>>", resourceManager.runtimeGoldProduction.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GoldStorage>>", resourceManager.runtimeGoldStorage.ToString());
            //change food values
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FoodUpkeep>>", resourceManager.runtimeFoodUpkeep.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FoodProduction>>", resourceManager.runtimeFoodProduction.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FoodStorage>>", resourceManager.runtimeFoodStorage.ToString());
            //change exotic values 
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ExoticGoodsUpkeep>>", resourceManager.runtimeEGUpkeep.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ExoticGoodsProduction>>", resourceManager.runtimeEGProduction.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ExoticGoodsStorage>>", resourceManager.runtimeEGStorage.ToString());
            // change allyindustryleaders happiness levels
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<MerchantHappiness>>", NPCLordHolder.AllyMerchant.Happiness.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<BuilderHappiness>>", NPCLordHolder.AllyBuilder.Happiness.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<GeneralHappiness>>", NPCLordHolder.AllyGeneral.Happiness.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<FarmerHappiness>>", NPCLordHolder.AllyFarmer.Happiness.ToString());
            stringfromSpymasterTemplate = stringfromSpymasterTemplate.Replace("<<ScholarHappiness>>", NPCLordHolder.AllyScholar.Happiness.ToString());

            using (var stream = new FileStream(filepathout, FileMode.Truncate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(stringfromSpymasterTemplate);
                    writer.Close();
                }
            }

            AssetDatabase.Refresh();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
