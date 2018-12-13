using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//NOTE: Should get placed on button and have the onclick be the researching function
public class ClickResearch : MonoBehaviour {
    public TechTree localTree;
    public StructureManager localStructs;
    public TimerTime localTimer;

    // default value until happiness is able to be accessed
    public NPCandLordHolder scienceHold;

    public TechTree scienceTree;

    // Update is called once per frame
    void Update()
    {
        if (!(scienceTree.DisplayCanvas()))
            GameObject.FindGameObjectWithTag("Researching").GetComponent<Canvas>().sortingOrder = 0;
        

        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().researchCanvas && scienceTree.DisplayCanvas())
        {
            GameObject.FindGameObjectWithTag("Research").GetComponent<Canvas>().sortingOrder = 0;
            GameObject.FindGameObjectWithTag("Researching").GetComponent<Canvas>().sortingOrder = 2;
            
        }

        // checks if cost is equal to local cost
        if (localTimer.dayCount >= localTree.localCost - scienceTree.totalBoost)
        {
            if(scienceTree.DisplayCanvas())
                GameObject.FindGameObjectWithTag("Research").GetComponent<Canvas>().sortingOrder = 2;

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().researchCanvas = false;
            GameObject.FindGameObjectWithTag("Researching").GetComponent<Canvas>().sortingOrder = 0;

            // places tech in researched tech array and resets local values
            localTree.runtimeNodes[localTree.holdPlace].researched = true;
            localTree.researched[localTree.holdPlace] = localTree.runtimeNodes[localTree.holdPlace].ChooseTech(scienceHold.AllyScholar.Happiness);
            localTree.totalBoost += localTree.researched[localTree.holdPlace].boost;

            // adds structure if one exists and places it into array to wait for building
            //if (localTree.runtimeNodes[localTree.holdPlace].structure.boost != 0)
            //    localStructs.runStruct[0] = localTree.runtimeNodes[localTree.holdPlace].structure;
            //else
            //    localStructs.runStruct[1] = localTree.runtimeNodes[localTree.holdPlace].structure;
            if (localTree.runtimeNodes[localTree.holdPlace].structure.boost != 0)
            {
                if (localStructs.runStruct[0] == null)
                {
                    localStructs.runStruct[0] = localTree.runtimeNodes[localTree.holdPlace].structure;
                    localStructs.holdPlace = 0;
                    
                }
                else
                {
                    localStructs.runStruct[1] = localTree.runtimeNodes[localTree.holdPlace].structure;
                    if(localStructs.runStruct[0].built == true)
                        localStructs.holdPlace = 1;
                }
                    
            }
                

            // resets values
            localTree.holdPlace = 1000;
            localTree.localCost = 1000;
        }

        
    }

    // checks if anything is being researched, if not, move on to new tech
    public void Researching()
    {
        if (localTree.localCost == 1000)
            for (int x = 0; x < 5; x++)
                if (localTree.runtimeNodes[x].researched == false)
                {
                    localTree.localCost = localTree.runtimeNodes[x].dayCost + localTimer.dayCount;
                    localTree.holdPlace = x;
                    GameObject.Find("Researching").GetComponentInChildren<Text>().text = " Researched on day " + (localTree.localCost - scienceTree.totalBoost) + " ";
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().researchCanvas = true;
                    return;
                }
    }

    private void OnDisable()
    {
        //localTree.totalBoost = 0;
        //localTree.localCost = 1000;
        //localTree.holdPlace = 1000;

        //localTree.Reset();
    }
}
