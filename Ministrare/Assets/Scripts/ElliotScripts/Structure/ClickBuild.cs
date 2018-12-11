using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBuild : MonoBehaviour {

    public StructureManager localStructs;
    public TimerTime localTimer;

    public TechTree prodTree;
	
	// Update is called once per frame
	void Update ()
    {
        if (!(prodTree.DisplayCanvas()))
            GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 0;


        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().buildingCanvas && prodTree.DisplayCanvas())
        {
            GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 0;
            GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 2;
        }

        // checks if cost is equal to local cost
        if (localTimer.dayCount >= localStructs.localCost - prodTree.totalBoost)
        {
           

            if (prodTree.DisplayCanvas())
                GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 2;

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().buildingCanvas = false;
            GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 0;

            // changes boolean to true and adds new boost to overall boost
            localStructs.runStruct[localStructs.holdPlace].built = true;
            localStructs.totalBoost += localStructs.runStruct[localStructs.holdPlace].boost;

            // resets values
            localStructs.holdPlace = 100;
            localStructs.localCost = 100;
        }
    }

    public void Building()
    {
        // checks if a structure is already built
        // if not, assign localCost and holdPlace to locations
        if(localStructs.runStruct[0] != null && localStructs.runStruct[0].built == false)
        {
            localStructs.localCost = localStructs.runStruct[0].dayCost + localTimer.dayCount;
            localStructs.holdPlace = 0;
        }
        else if(localStructs.runStruct[1] != null && localStructs.runStruct[1].built == false) 
        {
            localStructs.localCost = localStructs.runStruct[1].dayCost + localTimer.dayCount;
            localStructs.holdPlace = 1;
        }

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().buildingCanvas = true;
        //GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 2;
        //GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 0;
    }
}
