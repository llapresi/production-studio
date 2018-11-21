using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Structure Manager", menuName = "Ministrare/SingletonVars/StructureManager", order = 2)]
public class StructureManager : ScriptableObject {

    public string name;

    [Header("Initial Values")]
    [SerializeField]
    private Structure[] initStruct;
    
    public Structure[] runStruct;

    public int localCost;
    public int holdPlace;

    public int totalBoost;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        runStruct = new Structure[2];
        initStruct = runStruct;
    }
}


