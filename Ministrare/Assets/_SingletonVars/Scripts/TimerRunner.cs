using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRunner : MonoBehaviour {

    public TimerTime time;
    private static bool created = false;

    // Use this for initialization
    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        time.TimerTick(Time.deltaTime);

    }
}
