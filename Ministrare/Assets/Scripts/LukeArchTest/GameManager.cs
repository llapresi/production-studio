using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool hasStarted = false;
    [SerializeField]
    public NPCandLordHolder NPCLordHolder;
    [SerializeField]
    public ResourceManager resourceManager;
    [SerializeField]
    private string filepathin;
    [SerializeField]
    private string filepathout;
    [SerializeField]
    public Military military;
    public string Ending;

    [SerializeField]
    TimerTime timer;

    // list of tech trees and structures
    public List<TechTree> techTrees;
    public List<StructureManager> structures;

    public bool researchCanvas = false;
    public bool buildingCanvas = false;

    // Use this for initialization
    void Start()
    {
        if (hasStarted == false)
        {
            NPCLordHolder.Initialize();
            military.setParentObject();
            military.CreateALocation(-356, 594, "Mines");
            military.CreateALocation(435, -22, "Hunting Grounds");
            military.CreateALocation(673, -396, "Ruins");
            military.CreateALocation(1001, 435, "Enemy City");
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
        timer.NextDay();
    }
}
