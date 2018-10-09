using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Technology : MonoBehaviour {

    public string name;
    public Technology nextTech1 = new Technology();
    public Technology nextTech2 = new Technology();
    public bool researched = false;
    // component from resource management that allows edits to increased resources per turn (research/production/unit damage/etc...)
    // boolean allowing new struture to be built

  
}
