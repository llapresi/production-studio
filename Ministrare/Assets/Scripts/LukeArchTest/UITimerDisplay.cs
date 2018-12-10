using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimerDisplay : MonoBehaviour {

    // Use this for initialization
    public TimerTime currentTime;
    public TMPro.TextMeshProUGUI textDisplay;
    string timeOfDay;

    // Update is called once per frame
    void Update () {
        string toDisplay = "Time: ";
        if (currentTime.hours < 11 || currentTime.hours == 23)
            timeOfDay = "am";
        else
            timeOfDay = "pm";

        if ((currentTime.hours % 12 + 1) >= 10 && currentTime.minutes < 10)
            toDisplay += (currentTime.hours % 12 + 1) + ":0" + (int)currentTime.minutes + timeOfDay;
        else if ((currentTime.hours % 12 + 1) < 10 && currentTime.minutes > 10)
            toDisplay += "0" + (currentTime.hours % 12 + 1) + ":" + (int)currentTime.minutes + timeOfDay;
        else if ((currentTime.hours % 12 + 1) < 10 && currentTime.minutes < 10)
            toDisplay += "0" + (currentTime.hours % 12 + 1) + ":0" + (int)currentTime.minutes + timeOfDay;
        else
            toDisplay += (currentTime.hours % 12 + 1) + ":" + (int)currentTime.minutes + timeOfDay;

        textDisplay.text = toDisplay;
    }
}
