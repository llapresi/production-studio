using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimerRunner : MonoBehaviour {

    public TimerTime time;

    [SerializeField]
    private ResourceManager resourceManager;
    [SerializeField]
    private NPCandLordHolder NPCLordHolder;

    public UnityEvent onNewDay;

    // Make stuff go faster, for testing
    public float multiplier = 1;

    // Update is called once per frame
    void Update () {
        TimerTick(Time.deltaTime * multiplier);

    }

    public void TimerTick(float deltaTime)
    {
        // checks if game is paused and stops counting if it is
        if (time.paused == false)
        {
            // checks to see if the hour has ticked over, if not, keep counting
            if (time.minutes <= 60)
                time.minutes += deltaTime;
            else
            {
                // if the hour ticks over, increment
                time.hours++;

                // checks if day has ticked over, if so, increment day counter and reset day
                if (time.hours == 24)
                {
                    time.dayCount++;
                    time.hours = 0;
                    onNewDay.Invoke();
                }

                // resets minutes
                time.minutes = 0.0f;
            }
        }
    }
}
