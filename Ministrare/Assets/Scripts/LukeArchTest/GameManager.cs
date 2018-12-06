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
    [SerializeField]
    private Military military;
    public string Ending;
    // Use this for initialization
    void Start()
    {
        if (hasStarted == false)
        {
            NPCLordHolder.Initialize();
            military.setParentObject();
            military.CreateALocation(450, 450, "Mines");
            military.CreateEnemyUnit();
            //military.CreateEnemyUnit();
           //military.CreateEnemyUnit();
            hasStarted = true;

            // make the dialog for the spymaster with template and updated resource and npc values
            resourceManager.changeSpyMasterText();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
