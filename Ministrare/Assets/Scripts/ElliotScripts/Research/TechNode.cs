using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TechNode {

    public string name;
    public int dayCost;
    public bool researched;
    public Technology low = new Technology();
    public Technology mid = new Technology();
    public Technology high = new Technology();
    public Structure structure;
    public Technology ChooseTech(float scienceHappiness)
    {
        if (scienceHappiness < 1f)
            return low;
        else if (scienceHappiness > 2f)
            return high;
        else
            return mid;
    }
}
