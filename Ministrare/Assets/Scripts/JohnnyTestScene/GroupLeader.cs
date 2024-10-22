﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupLeader : MonoBehaviour {

    public string Text;
    public string BackGroundNum;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseEnter()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.blue;
    }

    void OnMouseExit()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }

    void OnMouseDown()
    {
        Debug.Log("Button Clicked");
        GameObject Manager = GameObject.Find("GameManager");
        OldGameManager gameManager = Manager.GetComponent<OldGameManager>();
        if (gameManager.BackGroundIn == false)
        {
            GameObject gameObject = GameObject.Find("BackGround" + BackGroundNum);
            Transform transform = gameObject.GetComponent<Transform>();
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
            gameManager.BackGroundIn = true;
        }
    }
}
