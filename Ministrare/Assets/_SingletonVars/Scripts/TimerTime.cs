using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

// A ScriptableObject that holds the current time in the game timer
// Reimplementation of Johnny's Timer
// Throw this into a MonoBehavior named "TimerRunner" that sets the value in this object
// Also, I should create an event to notify objects subscribed when timer runs out
// or when a timer tick happens
[CreateAssetMenu(fileName = "New TimerTime", menuName = "Ministrare/SingletonVars/Timer Time", order = 1)]
public class TimerTime : ScriptableObject
{
    // Starting values
    [Header("Initial Values")]
    // hours (minutes) and minutes(seconds) of game
    [SerializeField]
    private int initialHours;
    [SerializeField]
    private float initialMin;
    // day counter for each time a day ticks over
    [SerializeField]
    private int initialDayCount;


    [Space(3)]
    [Header("Runtime Values [No Touchy]")]
    public int hours;
    public float minutes;
    public int dayCount;
    public bool paused;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        hours = initialHours;
        minutes = initialMin;
        dayCount = initialDayCount;
    }
}