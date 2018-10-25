using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TechTree", menuName = "Ministrare/SingletonVars/TechTree", order = 1)]
public class TechTree : ScriptableObject {

    [Header("Initial Values")]
    [SerializeField]
    private TechNode[] initNodes;
    /*
    [SerializeField]
    private TechNode[] initProductionNodes;
    [SerializeField]
    private TechNode[] initMerchantNodes;
    [SerializeField]
    private TechNode[] initMilitaryNodes;
    [SerializeField]
    private TechNode[] initFarmNodes;
    */

    public TechNode[] runtimeNodes;
    /*
    public TechNode[] runtimeProductionNodes;
    public TechNode[] runtimeMerchantNodes;
    public TechNode[] runtimeMilitaryNodes;
    public TechNode[] runtimeFarmNodes;
    */

    public Technology[] researched;
    /*
    public Technology[] prodResearched;
    public Technology[] merchResearched;
    public Technology[] milResearched;
    public Technology[] farmResearched;
    */

    public int localCost;
    public int holdPlace;
    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;

        runtimeNodes = initNodes;
        /*
        runtimeProductionNodes = initProductionNodes;
        runtimeMerchantNodes = initMerchantNodes;
        runtimeMilitaryNodes = initMilitaryNodes;
        runtimeFarmNodes = initFarmNodes;
        */
        researched = new Technology[runtimeNodes.Length];
        /*
        prodResearched = new Technology[runtimeProductionNodes.Length];
        merchResearched = new Technology[runtimeMerchantNodes.Length];
        milResearched = new Technology[runtimeMilitaryNodes.Length];
        farmResearched = new Technology[runtimeFarmNodes.Length];
        */
    }
}
