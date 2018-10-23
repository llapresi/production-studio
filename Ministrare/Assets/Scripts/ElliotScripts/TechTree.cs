using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TechTree", menuName = "Ministrare/SingletonVars/TechTree", order = 1)]
public class TechTree : ScriptableObject {

    [Header("Initial Values")]
    [SerializeField]
    private TechNode[] initSciNodes;
    public TechNode[] runtimeSciNodes;
    public Technology[] researched;
    
    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        runtimeSciNodes = initSciNodes;
        researched = new Technology[runtimeSciNodes.Length];
    }
}
