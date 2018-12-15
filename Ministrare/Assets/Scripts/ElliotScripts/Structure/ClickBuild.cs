using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBuild : MonoBehaviour {

    public StructureManager localStructs;
    public TimerTime localTimer;

    public TechTree prodTree;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
            localStructs.Reset();

        int count = 0;
        int builtCount = 0;
        for (int x = 0; x < 2; x++)
        {
            if (localStructs.runStruct[x] != null)
            {
                if (localStructs.runStruct[x].built != true)
                    count++;
                else
                    builtCount++;
            }
                //count++;
            
        }

        gameObject.GetComponentInChildren<Text>().text = localStructs.name + ": " + count;

        if (builtCount == 2)
        {
            gameObject.GetComponentInChildren<Text>().text = "Completed";
            return;
        }
            

        

        //if (!(prodTree.DisplayCanvas()))
        //{
        //    GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 0;
        //}

        //if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().buildingCanvas && prodTree.DisplayCanvas())
        //{
        //    GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 0;
        //    GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 2;

        //}

        // checks if cost is equal to local cost
        //if (localTimer.dayCount >= localStructs.localCost - prodTree.totalBoost)
        //{
           

            //if (prodTree.DisplayCanvas())
            //    GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 2;

            //GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().buildingCanvas = false;
            //GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 0;

            // changes boolean to true and adds new boost to overall boost
            //localStructs.runStruct[localStructs.holdPlace].built = true;
            //localStructs.totalBoost += localStructs.runStruct[localStructs.holdPlace].boost;

            // resets values
            //localStructs.holdPlace = 1000;
            //localStructs.localCost = 1000;
        //}
    }

    public void Building()
    {
        // checks if a structure is already built
        // if not, assign localCost and holdPlace to locations
        if(localStructs.runStruct[0] != null && localStructs.runStruct[0].built == false)
        {
            //localStructs.localCost = localStructs.runStruct[0].dayCost + localTimer.dayCount;
            //localStructs.holdPlace = 0;
            //GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().buildingCanvas = true;
            //GameObject.Find("Building").GetComponentInChildren<Text>().text = " Built on day " + (localStructs.localCost - prodTree.totalBoost + " ");
            localStructs.runStruct[0].built = true;
            localStructs.holdPlace = 1000;
            localStructs.localCost = 1000;
            localStructs.totalBoost += localStructs.runStruct[0].boost;
        }
        else if(localStructs.runStruct[1] != null && localStructs.runStruct[1].built == false) 
        {
            //localStructs.localCost = localStructs.runStruct[1].dayCost + localTimer.dayCount;
            //localStructs.holdPlace = 1;
            //GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().buildingCanvas = true;
            //GameObject.Find("Building").GetComponentInChildren<Text>().text = " Built on day " + (localStructs.localCost - prodTree.totalBoost + " ");
            localStructs.runStruct[1].built = true;
            localStructs.holdPlace = 1000;
            localStructs.localCost = 1000;
            localStructs.totalBoost += localStructs.runStruct[1].boost;
        }

        
        //GameObject.FindGameObjectWithTag("Building").GetComponent<Canvas>().sortingOrder = 2;
        //GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 0;
    }

    private void OnDisable()
    {
        //localStructs.totalBoost = 0;
        //localStructs.localCost = 1000;
        //localStructs.holdPlace = 1000;
        //localStructs.Reset();
    }
}
