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
        
        // List of events to run
        List<IMinistrareEvent> events;

        private void Start()
        {
            // ADD A TEST EVENT HERE TO MAKE SURE THIS BS WORKS
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

    public class TestMinistrareEvent : IMinistrareEvent
    {
        private bool scheduleDestroy = false;
        private bool hasStarted = false;
        private TimerTime gameTimer;
        private string name;

        private float endTime;
        public bool ScheduleDestroy
        {
            get { return scheduleDestroy; }
            set { scheduleDestroy = value; }
        }

        public bool HasStarted
        {
            get { return hasStarted; }
            set { hasStarted = value; }
        }

        public TestMinistrareEvent(TimerTime p_timer, string p_name)
        {
            gameTimer = p_timer;
            name = p_name;
        }

        public void Start()
        {
            hasStarted = true;
            Debug.Log("started the event");
            endTime = gameTimer.minutes + 10;
        }

        public void End()
        {
            Debug.Log(string.Format("{0} has ended", name));
        }

        public void Update()
        {
            Debug.Log(string.Format("{0} TestEvent End: {1}", name, endTime - gameTimer.minutes));

            // Event sets itself to be destroyed after 10 seconds
            if(gameTimer.minutes >= endTime)
            {
                scheduleDestroy = true;
            }
        }
    }
}
