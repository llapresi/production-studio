using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMapLoad: MonoBehaviour {

    public Military military;

	// Use this for initialization
	void Start () {
        military.setParentObject();
        
        for(int x =0; x < military.allUnitsList.Count; x++)
        {
            Unit unit = military.allUnitsList[x];
            if (unit.IFF == 0)
            {
                GameObject Parent = Instantiate(military.unitImOne);
                unit.image = Parent;
                unit.image.transform.position = new Vector3(unit.xLoc, unit.yLoc, 0);
                unit.image.transform.parent = military.parent.transform;
            } else if (unit.IFF == 1)
            {
                GameObject Parent = Instantiate(military.unitImTwo);
                unit.image = Parent;
                unit.image.transform.position = new Vector3(unit.xLoc, unit.yLoc, 0);
                unit.image.transform.parent = military.parent.transform;
            }
        }
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
