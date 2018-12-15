using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                unit.image.transform.localPosition = new Vector3(unit.xLoc, unit.yLoc, 0);



            } else if (unit.IFF == 1 || unit.IFF == 2)
            {
                GameObject Parent = Instantiate(military.unitImTwo);
                unit.image = Parent;
                unit.image.name = unit.name;
                unit.image.transform.parent = military.parent.transform;
                unit.image.transform.localPosition = new Vector3(unit.xLoc, unit.yLoc, 0);
                unit.offmap = false;
            }
        }
        for(int y =0; y < military.resourceLocs.Count; y++)
        {
            Location location = military.resourceLocs[y];
            if (location.name == "Mines")
            {
                GameObject GO = Instantiate(military.Mines);
                location.image = GO;
                location.image.name = location.name;
                Image image = location.image.GetComponent<Image>();
                Color color = image.color;
                color.a = .5f;
                image.color = color;
                location.image.transform.parent = military.parent.transform;
                location.image.transform.localPosition = new Vector3(location.xLoc, location.yLoc, 0);

            }
            else if (location.name == "Hunting Grounds")
            {
                GameObject GO = Instantiate(military.HuntingGrounds);
                location.image = GO;
                location.image.name = location.name;
                Image image = location.image.GetComponent<Image>();
                Color color = image.color;
                color.a = .5f;
                image.color = color;
                location.image.transform.parent = military.parent.transform;
                location.image.transform.localPosition = new Vector3(location.xLoc, location.yLoc, 0);

            }
            else if (location.name == "Ruins")
            {
                GameObject GO = Instantiate(military.Ruins);
                location.image = GO;
                location.image.name = location.name;
                Image image = location.image.GetComponent<Image>();
                Color color = image.color;
                color.a = .5f;
                image.color = color;
                location.image.transform.parent = military.parent.transform;
                location.image.transform.localPosition = new Vector3(location.xLoc, location.yLoc, 0);

            }
            else if (location.name == "Enemy City")
            {
                GameObject GO = Instantiate(military.EnemyCity);
                location.image = GO;
                location.image.name = location.name;
                location.image.transform.parent = military.parent.transform;
                location.image.transform.localPosition = new Vector3(location.xLoc, location.yLoc, 0);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
