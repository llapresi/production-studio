using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ministrare.Events;
using UnityEditor;

namespace Ministrare.Events
{
    public class StableMinistareEvent : IMinistrareEvent
    {
        private bool scheduleDestroy = false;
        private bool hasStarted = false;
        private TimerTime gameTimer;
        private string name;

        private int endDay;
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

        public StableMinistareEvent(TimerTime p_timer, string p_name, int daysDuration)
        {
            gameTimer = p_timer;
            name = p_name;
            endDay = daysDuration + gameTimer.dayCount;
        }

        public void Start()
        {
            hasStarted = true;
            Debug.Log("started the event");
        }

        public void End()
        {
            // go to the npcandLordHolder and tell it to spin the wheel again
            NPCandLordHolder nPCandLordHolder = (NPCandLordHolder)AssetDatabase.LoadAssetAtPath("Assets/Scripts/JohnnyTestScene/ScriptableObjects/NPCandLordHolder.asset", typeof(NPCandLordHolder));
            nPCandLordHolder.stateOfMindRoll();
        }

        public void Update()
        {
            Debug.Log(string.Format("{0} TestEvent End: {1}", name, endDay - gameTimer.dayCount));

            // Event sets itself to be destroyed after 10 seconds
            if (gameTimer.dayCount >= endDay)
            {
                scheduleDestroy = true;
            }
        }
    }
}
