using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TechTree", menuName = "Ministrare/SingletonVars/TechTree", order = 1)]
public class TechTree : ScriptableObject {

    [Header("Initial Values")]
    [SerializeField]
    private TechNode[] initNodes;

    public TechNode[] runtimeNodes;

    public Technology[] researched;

    public int localCost;
    public int holdPlace;
    public int totalBoost;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;

        runtimeNodes = initNodes;
      
        researched = new Technology[runtimeNodes.Length];
       
    }
}
