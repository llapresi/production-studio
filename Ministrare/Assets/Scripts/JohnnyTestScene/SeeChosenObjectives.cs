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
            // get rid of unchosen scrollview if it still exists
            if (GameObject.Find("UnchosenScrollView") != null)
            {
                GameObject GD = GameObject.Find("UnchosenScrollView");
                Destroy(GD);
            }

            // let the other button know its unclicked
            GameObject UnchosenButton = GameObject.Find("See UnChosen Objectives");
            SeeUnchosenObjectives seeUnchosenObjectives = UnchosenButton.GetComponent<SeeUnchosenObjectives>();
            seeUnchosenObjectives.visiable = false;


            // add a scrollview for the buttons
            if (military.curObjList.Count != 0)
            {
                Vector3 vectortest = this.gameObject.transform.position;
                GameObject scrollViewObject = Instantiate(scrollView, vectortest, Quaternion.identity);
                GameObject CanvasGameScreen = GameObject.Find("MilitaryCanvas");
                scrollViewObject.transform.parent = CanvasGameScreen.transform;
                scrollViewObject.name = "ChosenScrollView";
                scrollViewObject.transform.localPosition = new Vector3(0, scrollViewObject.transform.localPosition.y, scrollViewObject.transform.localPosition.z);
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
                GameObject GD = GameObject.Find("ChosenScrollView");
                Destroy(GD);
            }
            visiable = false;
        }
    }
}
