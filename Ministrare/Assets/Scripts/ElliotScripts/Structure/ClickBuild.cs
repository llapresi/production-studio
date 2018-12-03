using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBuild : MonoBehaviour {

    public StructureManager localStructs;
    public TimerTime localTimer;

    public TechTree prodTree;

    // Use this for initialization
    void Start () {
        localStructs.localCost = -1;
        localStructs.holdPlace = -1;
	}
	
	// Update is called once per frame
	void Update () {
        // checks if cost is equal to local cost
        if (localTimer.dayCount == localStructs.localCost - prodTree.totalBoost)
        {
            // changes boolean to true and adds new boost to overall boost
            localStructs.runStruct[localStructs.holdPlace].built = true;
            localStructs.totalBoost += localStructs.runStruct[localStructs.holdPlace].boost;
            
            // resets values
            localStructs.holdPlace = -1;
            localStructs.localCost = -1;
        }
    }

    public void Building()
    {
        // checks if a structure is already built
        // if not, assign localCost and holdPlace to locations
        if(localStructs.runStruct[0].built == false)
        {
            localStructs.localCost = localStructs.runStruct[0].dayCost + localTimer.dayCount;
            localStructs.holdPlace = 0;
        }
        else 
        {
            localStructs.localCost = localStructs.runStruct[1].dayCost + localTimer.dayCount;
            localStructs.holdPlace = 1;
        }
        
    }
}
