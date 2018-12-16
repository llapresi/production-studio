using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Structure Manager", menuName = "Ministrare/SingletonVars/StructureManager", order = 2)]
public class StructureManager : ScriptableObject {

    public string name;

    [Header("Initial Values")]
    [SerializeField]
    private Structure[] initStruct = new Structure[2];
    
    public Structure[] runStruct;

    public int localCost;
    public int holdPlace;

    public int totalBoost;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        runStruct = new Structure[2];
        //runStruct = initStruct;
        initStruct = runStruct;
        //for (int x =0; x < runStruct.Length;x++)
        //{
        //    runStruct[x].built = false;
        //}
        localCost = 1000;
        holdPlace = 1000;
        totalBoost = 0;
    }

    public void Reset()
    {
        runStruct = new Structure[2];
        //runStruct = initStruct;
        initStruct = runStruct;
        //for (int x = 0; x < runStruct.Length; x++)
        //{
        //    runStruct[x].built = false;
        //}
        localCost = 1000;
        holdPlace = 1000;
        totalBoost = 0;
    }
}


