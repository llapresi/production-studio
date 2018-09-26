using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        this.gameObject.transform.position = new Vector3(23.8f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        GameObject gameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameObject.GetComponent<GameManager>();
        gameManager.BackGroundIn = false;
    }
}
