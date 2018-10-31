using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ministrare.Events;

namespace Ministrare.Events
{
    public class MinistrareEventRunner : MonoBehaviour
    {
        // Array of events to run
        List<IMinistrareEvent> events;

        private void Start()
        {
            // ADD A TEST EVENT HERE TO MAKE SURE THIS BS WORKS
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
                    events[i].End();
                    events.Remove(events[i]);
                    continue;
                }
                if (events[i].HasStarted == false)
                {
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

        public void Start()
        {
            Debug.Log("started the event");
            hasStarted = true;
        }

        public void End()
        {
            scheduleDestroy = false;
        }

        public void Update()
        {
            Debug.Log(string.Format("Current Deltatime: {0}", Time.deltaTime));
        }
    }
}
