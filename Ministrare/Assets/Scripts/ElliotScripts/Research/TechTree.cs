using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TechTree", menuName = "Ministrare/SingletonVars/TechTree", order = 1)]
public class TechTree : ScriptableObject {
    public string name;

    [Header("Initial Values")]
    [SerializeField]
    private TechNode[] initNodes;

    public TechNode[] runtimeNodes;

    public Technology[] researched;

    public int localCost;
    public int holdPlace;
    public int totalBoost;

    public bool displayCanvas = false;

    // changes canvas boolean between true and false
    public void SwitchCanvas()
    {
        displayCanvas = !displayCanvas;     
    }

    // returns the canvas boolean
    public bool DisplayCanvas()
    {
        return displayCanvas;
    }

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;

        runtimeNodes = initNodes;
      
        researched = new Technology[runtimeNodes.Length];
    }

   
}
