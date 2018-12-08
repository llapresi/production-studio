using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ministrare.Events;

namespace Ministrare.Events
{
    public class MinistrareEventRunner : MonoBehaviour
    {
        // Reference to our TimerTime singleton var
        // Plug into events so that they run on the game time and not the delta time
        public TimerTime gameTimer;

        // Actual singleton for the event runner
        // After Milestone 2 submission we need to refactor this
        public static MinistrareEventRunner instance;

        // List of events to run
        List<IMinistrareEvent> events;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);

            // ADD A TEST EVENT HERE TO MAKE SURE THIS BS WORKS
            events = new List<IMinistrareEvent>();
        }

        private void Start()
        {

        }

        public void Reset()
        {
            events = new List<IMinistrareEvent>();
        }

        // This function is only for the even test scene, delete this once we're doing more fully fledged stuff
        public void AddEvent(IMinistrareEvent eventToAdd)
        {
            events.Add(eventToAdd);
        }

        // Update is called once per frame
        void Update()
        {
            // Using a for loop because we actually do need to execute this in order to handle adding and removing
            // I (think)
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].ScheduleDestroy == true)
                {
                    // Remove event from the list if it is scheduled to be destroyed
                    events[i].End();
                    events.Remove(events[i]);
                    continue;
                }
                if (events[i].HasStarted == false)
                {
                    // Start event if it is addded to the array but has not been started yet
                    events[i].Start();
                }
                events[i].Update();
            }
        }
    }
}
