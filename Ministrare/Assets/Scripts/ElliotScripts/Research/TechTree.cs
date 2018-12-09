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

    public void Reset()
    {
        if(runtimeNodes != null)
        {
            for(int x = 0; x < runtimeNodes.Length; x++)
            {
                runtimeNodes[x].researched = false;
                if (runtimeNodes[x].structure.boost != 0)
                    runtimeNodes[x].structure.built = false;
            }

            totalBoost = 0;
            localCost = -1;
            holdPlace = -1;
            displayCanvas = false;
        }
    }

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;

        runtimeNodes = initNodes;
      
        researched = new Technology[runtimeNodes.Length];
    }

   
}
