﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ScriptableObject that holds the current time in the game timer
// Reimplementation of Johnny's Timer
// Throw this into a MonoBehavior named "TimerRunner" that sets the value in this object
// Also, I should create an event to notify objects subscribed when timer runs out
// or when a timer tick happens
[CreateAssetMenu(fileName = "New TimerTime", menuName = "Ministrare/Timer Time", order = 1)]
public class TimerTime : ScriptableObject,
    ISerializationCallbackReceiver
{
    // Starting values

    // hours (minutes) and minutes(seconds) of game
    [SerializeField]
    private int initialHours;
    [SerializeField]
    private float initialMin;
    // day counter for each time a day ticks over
    [SerializeField]
    private int initialDayCount;

    [System.NonSerialized]
    public int hours;
    [System.NonSerialized]
    public float minutes;
    [System.NonSerialized]
    public int dayCount;
    [System.NonSerialized]
    public bool paused;

    public void OnAfterDeserialize()
    {
        hours = initialHours;
        minutes = initialMin;
        dayCount = initialDayCount;
    }

    public void TimerTick(float deltaTime)
    {
        // checks if game is paused and stops counting if it is
        if (paused == false)
        {
            // checks to see if the hour has ticked over, if not, keep counting
            if (minutes <= 60)
                minutes += deltaTime;
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

    public void OnBeforeSerialize()
    {

    }
}