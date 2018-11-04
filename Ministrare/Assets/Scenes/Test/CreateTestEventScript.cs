using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Including using reference to events;
using Ministrare.Events;

public class CreateTestEventScript : MonoBehaviour {

    // Use this for initialization
    public TMPro.TMP_InputField name;
    public TimerTime time;
    public MinistrareEventRunner runner;
	
    public void CreateTestEvent()
    {
        var newEvent = new TestMinistrareEvent(time, name.text);
        runner.AddEvent(newEvent);
    }
}
