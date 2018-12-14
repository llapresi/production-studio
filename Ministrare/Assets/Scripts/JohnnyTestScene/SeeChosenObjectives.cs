using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeChosenObjectives : MonoBehaviour {

    public Military military;
    public GameObject button;
    public GameObject scrollView;
    public bool visiable;
    private float Xchange;
    private float Ychange;

    public void Start()
    {
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(pressSeeObjectives);
        visiable = false;
        Xchange = 200;
        Ychange = 0;
    }
    // create some buttons not too far from it saying where avalible objectives are for players
    public void pressSeeObjectives()
    {
        if (visiable == false)
        {
            if (GameObject.Find("UnchosenScrollView") != null)
            {
                GameObject GD = GameObject.Find("UnchosenScrollView");
                CanvasGroup CG = GD.GetComponent<CanvasGroup>();
                CG.alpha = 0;
                CG.interactable = false;
                CG.blocksRaycasts = false;
                GameObject[] UObjectiveButtons = GameObject.FindGameObjectsWithTag("UObjectiveButton");
                foreach (GameObject GO in UObjectiveButtons)
                {
                    Destroy(GO);
                }
            }

            // let the other button know its unclicked
            GameObject UnchosenButton = GameObject.Find("See UnChosen Objectives");
            SeeUnchosenObjectives seeUnchosenObjectives = UnchosenButton.GetComponent<SeeUnchosenObjectives>();
            seeUnchosenObjectives.visiable = false;


            // add a scrollview for the buttons
            if (military.curObjList.Count != 0)
            {
                if (GameObject.Find("ChosenScrollView") != null)
                {
                    GameObject CSV = GameObject.Find("ChosenScrollView");
                    CanvasGroup CG = CSV.GetComponent<CanvasGroup>();
                    CG.alpha = 1;
                    CG.interactable = true;
                    CG.blocksRaycasts = true;
                }
            }

            foreach (Targets targets in military.curObjList)
                {
                bool unitbool = false;
                bool locationbool = false;
                ChosenobjectiveSelected OS = button.GetComponent<ChosenobjectiveSelected>();
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
                GameObject GO = GameObject.Find("ChosenScrollView");
                Transform VP = GO.transform.Find("Viewport");
                Transform SC = VP.transform.Find("ScrollContent");
                madeButton.transform.parent = SC;
            }
            if (military.curObjList.Count > 0)
            {
                visiable = true;
            }
            else
            {
                visiable = false;
            }
            Ychange = 0;
        }
        else if (visiable == true)
        {
            if (GameObject.Find("ChosenScrollView") != null)
            {
                GameObject CSV = GameObject.Find("ChosenScrollView");
                CanvasGroup CG = CSV.GetComponent<CanvasGroup>();
                CG.alpha = 0;
                CG.interactable = false;
                CG.blocksRaycasts = false;
                GameObject[] CObjectiveButtons = GameObject.FindGameObjectsWithTag("CObjectiveButton");
                foreach (GameObject GO in CObjectiveButtons)
                {
                    Destroy(GO);
                }
            }
            visiable = false;
        }
    }
}
