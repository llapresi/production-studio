using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TechTree", menuName = "Ministrare/SingletonVars/TechTree", order = 1)]
public class TechTree : ScriptableObject {

    [Header("Initial Values")]
    [SerializeField]
    private TechNode[] initialNodes;
    public TechNode[] runtimeNodes;
    
    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        runtimeNodes = initialNodes;
    }
}
