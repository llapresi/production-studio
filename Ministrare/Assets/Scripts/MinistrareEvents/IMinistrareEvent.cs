using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ministrare.Events
{
    public interface IMinistrareEvent
    {
        void Update();
        void Start();
        void End();
        bool ScheduleDestroy { get; set; }
        bool HasStarted { get; set; }
    }
}
