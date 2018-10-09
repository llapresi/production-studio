using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryTree : MonoBehaviour {
    public Technology firstTech;

    // Use this for initialization
    void Start () {
        // level 0 techs
        firstTech = new Technology();
        firstTech.name = "Weapons"; firstTech.researched = true;

        // level 1 techs
        Technology level1_1 = firstTech.nextTech1;
        Technology level1_2 = firstTech.nextTech2;

        // level 2 techs
        Technology level2_1 = level1_1.nextTech1;
        Technology level2_2 = level1_1.nextTech2;

        Technology level2_1a = level1_2.nextTech1;
        Technology level2_2a = level1_2.nextTech2;

        // level 3 techs
        Technology level3_1 = level2_1.nextTech1;
        Technology level3_2 = level2_1.nextTech2;

        Technology level3_1a = level2_2.nextTech1;
        Technology level3_2a = level2_2.nextTech2;

        Technology level3_1b = level2_1a.nextTech1;
        Technology level3_2b = level2_1a.nextTech2;

        Technology level3_1c = level2_2a.nextTech1;
        Technology level3_2c = level2_2a.nextTech2;

        // level 4 techs
        Technology level4_1 = level3_1.nextTech1;
        Technology level4_2 = level3_1.nextTech2;

        Technology level4_1a = level3_2.nextTech1;
        Technology level4_2a = level3_2.nextTech2;

        Technology level4_1b = level3_1a.nextTech1;
        Technology level4_2b = level3_1a.nextTech2;

        Technology level4_1c = level3_2a.nextTech1;
        Technology level4_2c = level3_2a.nextTech2;

        Technology level4_1d = level3_1b.nextTech1;
        Technology level4_2d = level3_1b.nextTech2;

        Technology level4_1e = level3_2b.nextTech1;
        Technology level4_2e = level3_2b.nextTech2;

        Technology level4_1f = level3_1c.nextTech1;
        Technology level4_2f = level3_1c.nextTech2;

        Technology level4_1g = level3_2c.nextTech1;
        Technology level4_2g = level3_2c.nextTech2;
    }
	
	
}
