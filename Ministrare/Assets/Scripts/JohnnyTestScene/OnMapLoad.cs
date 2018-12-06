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
                unit.image.name = unit.name;
                unit.image.transform.localPosition = new Vector3(unit.xLoc, unit.yLoc, 0);
                unit.image.transform.parent = military.parent.transform;
                if (unit.offmap)
                {
                    unit.image.transform.localPosition = new Vector3(unit.xLoc, unit.yLoc, 0);
                    unit.offmap = false;
                }
                else
                {
                    unit.image.transform.position = new Vector3(unit.xLoc, unit.yLoc, 0);
                }


            } else if (unit.IFF == 1 || unit.IFF == 2)
            {
                GameObject Parent = Instantiate(military.unitImTwo);
                unit.image = Parent;
                unit.image.name = unit.name;
                unit.image.transform.parent = military.parent.transform;
                if (unit.offmap)
                {
                    unit.image.transform.localPosition = new Vector3(unit.xLoc, unit.yLoc, 0);
                    unit.offmap = false;
                    if(unit.IFF == 2)
                    {
                        unit.xLoc = unit.image.transform.position.x;
                        unit.yLoc = unit.image.transform.position.y;
                    }
                }
                else
                {
                    unit.image.transform.position = new Vector3(unit.xLoc, unit.yLoc, 0);
                }



            }
        }
        for(int y =0; y < military.resourceLocs.Count; y++)
        {
            Location location = military.resourceLocs[y];
            if (location.name == "Mines")
            {
                GameObject GO = Instantiate(military.resourceLocation1);
                location.image = GO;
                location.image.name = location.name;
                location.image.transform.position = new Vector3(location.xLoc, location.yLoc, 0);
                location.image.transform.parent = military.parent.transform;

            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
