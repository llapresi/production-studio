using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Including using reference to events;
using Ministrare.Events;

public class CreateTestEventScript : MonoBehaviour {

    // Use this for initialization
    public TMPro.TMP_InputField name;
    public TimerTime time;
	
    public void CreateTestEvent()
    {
        var newEvent = new TestMinistrareEvent(time, name.text);
        MinistrareEventRunner.instance.AddEvent(newEvent);
    }
}
