﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCanvas : MonoBehaviour {

    // takes in science and production tree for research and build canvas
    public TechTree sciTree;
    public TechTree prodTree;

    // checks the canvas display boolean in the tech trees to 
    // see which canvas needs to be displayed
    public void OnEnable()
    {
        // if the science tree boolean is true, change order of 
        // research canvas to one and displays it
        if(sciTree.DisplayCanvas())
        {
            GameObject.FindGameObjectWithTag("Research").GetComponent<Canvas>().sortingOrder = 1;
        }
        else if(prodTree.DisplayCanvas())  // do the same for production if science tree boolean is false
        {
            GameObject.FindGameObjectWithTag("Build").GetComponent<Canvas>().sortingOrder = 1;
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
    }
    
}