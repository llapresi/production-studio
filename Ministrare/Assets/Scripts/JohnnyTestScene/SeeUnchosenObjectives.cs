﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeUnchosenObjectives : MonoBehaviour {

    public Military military;
    public GameObject button;
    public bool visiable;
    public GameObject scrollView;
    private float Xchange;
    private float Ychange;

    public void Start()
    {
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(pressSeeObjectives);
        visiable = false;
        Xchange = 200;
        Ychange = 5;
    }
    // create some buttons not too far from it saying where avalible objectives are for players
    public void pressSeeObjectives()
    {
        if (visiable == false)
        {

            // get rid of chosen Scroll View if it still exists
            if (GameObject.Find("ChosenScrollView") != null)
            {
                GameObject GD = GameObject.Find("ChosenScrollView");
                CanvasGroup CG = GD.GetComponent<CanvasGroup>();
                CG.alpha = 0;
                CG.interactable = false;
                CG.blocksRaycasts = false;
                GameObject[] CObjectiveButtons = GameObject.FindGameObjectsWithTag("CObjectiveButton");
                foreach (GameObject GO in CObjectiveButtons)
                {
                    Destroy(GO);
                }
            }

            // let the other button know its unclicked
            GameObject chosenButton = GameObject.Find("See Chosen Objectives");
            SeeChosenObjectives seechosenObjectives = chosenButton.GetComponent<SeeChosenObjectives>();
            seechosenObjectives.visiable = false;

            // tell the scrollview to show and that it should accept input
            if (military.unchosenObjList.Count != 0)
            {
                if (GameObject.Find("UnchosenScrollView") != null)
                {
                    GameObject USV = GameObject.Find("UnchosenScrollView");
                    CanvasGroup CG = USV.GetComponent<CanvasGroup>();
                    CG.alpha = 1;
                    CG.interactable = true;
                    CG.blocksRaycasts = true;
                }
            }

            foreach (Targets targets in military.unchosenObjList)
                {
                    bool unitbool = false;
                    bool locationbool = false;
                    UnchosenobjectiveSelected OS = button.GetComponent<UnchosenobjectiveSelected>();
                    if (targets.GetType() == typeof(Unit))
                    {
                        Unit unit = (Unit)targets;
                        OS.Name = unit.name;
                        unitbool = true;
                    }
                    else
                    {
                        Location location = (Location)targets;
                        OS.Name = location.name;
                        locationbool = true;
                    }
                    // give it position
                    Vector3 vector3 = this.gameObject.transform.position;
                    vector3.x += Xchange;
                    vector3.y += Ychange;

                    // place it on the map
                    GameObject CanvasGameScreen = GameObject.Find("MilitaryCanvas");
                    GameObject madeButton = Instantiate(button, vector3, Quaternion.identity);
                    Ychange -= 40;
                    if (unitbool)
                    {
                    madeButton.GetComponentInChildren<Text>().text = "Attack " + OS.Name;
                    }
                    else if (locationbool)
                    {
                    madeButton.GetComponentInChildren<Text>().text = "Capture " + OS.Name;
                    }
                //make the button parent equal to content
                GameObject GO = GameObject.Find("UnchosenScrollView");
                Transform VP = GO.transform.Find("Viewport");
                Transform SC = VP.transform.Find("ScrollContent");
                madeButton.transform.parent = SC;
            }
            if (military.unchosenObjList.Count > 0)
            {
                visiable = true;
            }
            else
            {
                visiable = false;
            }
            Ychange = 5;
        }
        else if (visiable == true)
        {
         
            if (GameObject.Find("UnchosenScrollView") != null)
            {
                GameObject USV = GameObject.Find("UnchosenScrollView");
                CanvasGroup CG = USV.GetComponent<CanvasGroup>();
                CG.alpha = 0;
                CG.interactable = false;
                CG.blocksRaycasts = false;
                GameObject[] UObjectiveButtons = GameObject.FindGameObjectsWithTag("UObjectiveButton");
                foreach (GameObject GO in UObjectiveButtons)
                {
                    Destroy(GO);
                }
            }

            
            visiable = false;
        }
    }
}
