using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: Should get placed on button and have the onclick be the researching function
public class ClickResearch : MonoBehaviour {
    public TechTree localTree;
    public TimerTime localTimer;

    float scienceHappiness;  // default value until happiness is able to be accessed

    private void Start()
    {
        localTree.holdPlace = -1;
        localTree.localCost = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // checks if cost is equal to local cost
        if (localTimer.dayCount == localTree.localCost)
        {
            // places tech in researched tech array and resets local values
            localTree.runtimeNodes[localTree.holdPlace].researched = true;
            localTree.researched[localTree.holdPlace] = localTree.runtimeNodes[localTree.holdPlace].ChooseTech(scienceHappiness);
            localTree.holdPlace = -1;
            localTree.localCost = -1;
        }
        Researching();
    }

    // checks if anything is being researched, if not, move on to new tech
    public void Researching()
    {
        if (localTree.localCost == -1)
            for (int x = 0; x < 5; x++)
                if (localTree.runtimeNodes[x].researched == false)
                {
                    localTree.localCost = localTree.runtimeNodes[x].dayCost + localTimer.dayCount;
                    localTree.holdPlace = x;
                    return;
                }
    }
}
