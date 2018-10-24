using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: Should get placed on button and have the onclick be the researching function
public class ClickResearch : MonoBehaviour {
    public TechTree localTree;
    public TimerTime localTimer;

    int holdPlace;
    int localCost;

    float scienceHappiness;  // default value until happiness is able to be accessed

    // Use this for initialization
    void Start()
    {
        holdPlace = -1;
        localCost = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // checks if cost is equal to local cost
        if (localTimer.dayCount == localCost)
        {
            // places tech in researched tech array and resets local values
            localTree.runtimeNodes[holdPlace].researched = true;
            localTree.researched[holdPlace] = localTree.runtimeNodes[holdPlace].ChooseTech(scienceHappiness);
            holdPlace = -1;
            localCost = -1;
        }
    }

    // checks if anything is being researched, if not, move on to new tech
    public void Researching()
    {
        if (localCost == -1)
            for (int x = 0; x < 5; x++)
                if (localTree.runtimeNodes[x].researched == false)
                {
                    localCost = localTree.runtimeNodes[x].dayCost + localTimer.dayCount;
                    holdPlace = x;
                    return;
                }
    }
}
