using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresistantParent : MonoBehaviour {

    private static bool created = false;
    GameObject TimerCanvas;

    // Use this for initialization
    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            TimerCanvas = GameObject.Find("TimerCanvas");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetTimerCanvasActive()
    {
        TimerCanvas.SetActive(true);
    }

}
