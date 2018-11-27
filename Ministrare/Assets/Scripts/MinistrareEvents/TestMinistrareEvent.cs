using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ministrare.Events;

namespace Ministrare.Events
{
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
            if (gameTimer.minutes >= endTime)
            {
                scheduleDestroy = true;
            }
        }
    }
}
