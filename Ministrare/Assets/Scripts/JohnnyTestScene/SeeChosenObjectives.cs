using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeeChosenObjectives : MonoBehaviour {

    public Military military;
    public GameObject button;
    public bool visiable;

    public void Start()
    {
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(pressSeeObjectives);
        visiable = false;
    }
    // create some buttons not too far from it saying where avalible objectives are for players
    public void pressSeeObjectives()
    {
        if (visiable == false)
        {

            
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
                    vector3.x += 100;
                    // place it on the map
                    GameObject CanvasGameScreen = GameObject.Find("CanvasGameScreen");
                    GameObject madeButton = Instantiate(button, vector3, Quaternion.identity);
                    if (unitbool)
                    {
                        madeButton.GetComponentInChildren<Text>().text = "Attack " + OS.Name;
                    }
                    else if (locationbool)
                    {
                        madeButton.GetComponentInChildren<Text>().text = "Capture " + OS.Name;
                    }
                madeButton.transform.parent = CanvasGameScreen.transform;
                }
            if (military.curObjList.Count > 0)
            {
                visiable = true;
            }
            else
            {
                visiable = false;
            }
            
        }
        else if (visiable == true)
        {
            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.name == "CObjectiveButton")
                    Destroy(go);
            }
            visiable = false;
        }
    }
}
