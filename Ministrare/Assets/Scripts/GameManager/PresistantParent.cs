using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresistantParent : MonoBehaviour {

    private static bool created = false;
    GameObject TimerCanvas;
    GameObject MilitaryCanvas;
    GameObject ResearchCanvas;
    GameObject BuildCanvas;
    GameObject ResearchingCanvas;
    GameObject BuildingCanvas;

    // Use this for initialization
    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            TimerCanvas = GameObject.Find("TimerCanvas");
            MilitaryCanvas = GameObject.Find("MilitaryCanvas");
            ResearchCanvas = GameObject.Find("Research Canvas");
            BuildCanvas = GameObject.Find("Build Canvas");
            ResearchingCanvas = GameObject.Find("Researching Canvas");
            BuildingCanvas = GameObject.Find("Building Canvas");


        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetCanvasesActivetrue()
    {
        TimerCanvas.SetActive(true);
        MilitaryCanvas.SetActive(true);
        ResearchCanvas.SetActive(true);
        BuildCanvas.SetActive(true);
        ResearchingCanvas.SetActive(true);
        BuildingCanvas.SetActive(true);
    }
    public void SetCanvasesActivefalse()
    {
        TimerCanvas.SetActive(false);
        MilitaryCanvas.SetActive(false);
        ResearchCanvas.SetActive(false);
        BuildCanvas.SetActive(false);
        ResearchingCanvas.SetActive(false);
        BuildingCanvas.SetActive(false);
    }

    // special code to destroy our parent without screwing things up
    public void Destroy()
    {
        created = false;
        Destroy(this.gameObject);
    }


}
