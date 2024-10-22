﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour {

    // takes in science and production tree for research and build canvas
    public TechTree sciTree;
    public TechTree prodTree;
    public Military military;

    // checks the canvas display boolean in the tech trees to 
    // see which canvas needs to be displayed
    public void OnEnable()
    {
        // if the science tree boolean is true, change order of 
        // research canvas to one and displays it
        if(sciTree.DisplayCanvas())
        {
            GameObject.FindGameObjectWithTag("Research").GetComponent<Canvas>().sortingOrder = 2;
        }
        else if(prodTree.DisplayCanvas())  // do the same for production if science tree boolean is false
        {
            GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 2;
        }
        else if(military.DisplayCanvas()) // do the same for military if military bool is true
        {
            GameObject.FindGameObjectWithTag("Military").GetComponent<Canvas>().sortingOrder = 2;
        }
    }

    // When the player clicks the exit button checks which tree
    // boolean is true and then stops displaying the canvas and 
    // changes the tree boolean back to false
    public void RevertCanvas()
    {
        // changes sorting order back to 0 and changes 
        // boolean if science tree boolean is true
        if (sciTree.DisplayCanvas())
        {
            GameObject.FindGameObjectWithTag("Research").GetComponent<Canvas>().sortingOrder = 0;
            sciTree.SwitchCanvas();
        }
        else if(prodTree.DisplayCanvas())  // same but for production tree
        {
            GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 0;
            prodTree.SwitchCanvas();
        }
        else if (military.DisplayCanvas()) // do the same for military if military bool is true
        {
            GameObject.FindGameObjectWithTag("Military").GetComponent<Canvas>().sortingOrder = 0;
            military.SwitchCanvas();
            //get rid of any active Objective buttons 
            // get rid of chosen objective buttons if they exists
            GameObject[] CObjectiveButtonList = GameObject.FindGameObjectsWithTag("CObjectiveButton");

            for (int x = 0; x < CObjectiveButtonList.Length; x++)
            {
                GameObject.Destroy(CObjectiveButtonList[x]);
            }

            // get rid of unchosen objective buttons if they exists
            GameObject[] UObjectiveButtonList = GameObject.FindGameObjectsWithTag("UObjectiveButton");

            for (int x = 0; x < UObjectiveButtonList.Length; x++)
            {
                GameObject.Destroy(UObjectiveButtonList[x]);
            }
            // tell both dropboxes to dissapper for now
            GameObject USV = GameObject.Find("UnchosenScrollView");
            CanvasGroup CG = USV.GetComponent<CanvasGroup>();
            CG.alpha = 0;
            CG.interactable = false;
            CG.blocksRaycasts = false;
            GameObject CSV = GameObject.Find("ChosenScrollView");
            CanvasGroup CG2 = CSV.GetComponent<CanvasGroup>();
            CG2.alpha = 0;
            CG2.interactable = false;
            // tell both buttons that their visablity is false
            GameObject chosenButton = GameObject.Find("See Chosen Objectives");
            SeeChosenObjectives seechosenObjectives = chosenButton.GetComponent<SeeChosenObjectives>();
            seechosenObjectives.visiable = false;
            GameObject UnchosenButton = GameObject.Find("See UnChosen Objectives");
            SeeUnchosenObjectives seeUnchosenObjectives = UnchosenButton.GetComponent<SeeUnchosenObjectives>();
            seeUnchosenObjectives.visiable = false;

        }
    }
    
}
