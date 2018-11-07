using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Elliot Privateer
 * Ministrare - Medieval Politics
 * 09/27/18
 * Timer Script: Based on hours and minutes of a normal day (scaled to minutes and seconds, respectively), used to keep track of time and day in game 
 */
public class Timer : MonoBehaviour {

    // hours (minutes) and minutes(seconds) of game
    public int hours;
    public float minutes;

    // day counter for each time a day ticks over
    public int dayCount;

    // string used to determine AM and PM of time
    string timeOfDay;

    public bool paused;
   
	// Use this for initialization
	void Start () {

        hours = 0;
        minutes = 0.0f;
        dayCount = 0;

        paused = false;
    }
	
	// Update is called once per frame
	void Update () {

        // checks if game is paused and stops counting if it is
        if(paused == false)
        {
            // checks to see if the hour has ticked over, if not, keep counting
            if (minutes <= 60)
                minutes += Time.deltaTime;
            else
            {
                // if the hour ticks over, increment
                hours++;

                // checks if day has ticked over, if so, increment day counter and reset day
                if (hours == 24)
                {
                    dayCount++;
                    hours = 0;

                }

                // resets minutes
                minutes = 0.0f;
            }

        }


    }

    // function for basic GUI text to display time
    private void OnGUI()
    {
        if (hours < 11 || hours == 23)
            timeOfDay = "am";
        else
            timeOfDay = "pm";
        
        if((hours % 12 + 1) >= 10 && minutes < 10)
            GUI.TextField(new Rect(40, 10, 100, 50), "" + (hours % 12 + 1) + ":0" + (int)minutes + timeOfDay);
        else if((hours % 12 + 1) < 10 && minutes > 10)
            GUI.TextField(new Rect(40, 10, 100, 50), "0" + (hours % 12 + 1) + ":" + (int)minutes + timeOfDay);
        else if((hours % 12 + 1) < 10 && minutes < 10)
            GUI.TextField(new Rect(40, 10, 100, 50), "0" + (hours % 12 + 1) + ":0" + (int)minutes + timeOfDay);
        else
            GUI.TextField(new Rect(40, 10, 100, 50), "" + (hours % 12 + 1) + ":" + (int)minutes + timeOfDay);
    }

   
}
