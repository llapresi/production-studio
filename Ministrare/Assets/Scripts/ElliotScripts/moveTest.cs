using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTest : MonoBehaviour {

    float x;
	// Use this for initialization
	void Start () {
		x = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        x += 0.01f;
        Vector3 vec = new Vector3(x, 0, 0);
        GetComponent<Transform>().position = vec;
	}
}
