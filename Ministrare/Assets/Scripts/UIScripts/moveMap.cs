﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveMap : MonoBehaviour, IDragHandler {

    private float xloc = 0;
    private float yloc = 0;
    private float previousXLoc = 0;
    private float previousYLoc = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        UpdateOffset();

	}


    public void OnDrag(PointerEventData eventData)
    {
        
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + (xloc - previousXLoc), gameObject.transform.position.y + (yloc - previousYLoc), gameObject.transform.position.z);
            
    }

    public void UpdateOffset()
    {
        previousXLoc = xloc;
        previousYLoc = yloc;
        xloc = Input.mousePosition.x;
        yloc = Input.mousePosition.y;
    }
}