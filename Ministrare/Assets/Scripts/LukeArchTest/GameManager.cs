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

    // list of tech trees and structures
    public List<TechTree> techTrees;
    public List<StructureManager> structures;

    // Use this for initialization
    void Start()
    {
        if (hasStarted == false)
        {
            NPCLordHolder.Initialize();
            military.setParentObject();
            military.CreateALocation(-450, 750, "Mines");
            military.CreateALocation(550, -28, "Hunting Grounds");
            military.CreateALocation(850, -500, "Ruins");
            military.CreateALocation(1265, 550, "Enemy City");
            military.displayCanvas = false;
            //military.CreateFriendlyUnit();
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
