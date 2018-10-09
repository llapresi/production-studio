using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRunner : MonoBehaviour {

    public TimerTime time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time.TimerTick(Time.deltaTime);

    }
}
