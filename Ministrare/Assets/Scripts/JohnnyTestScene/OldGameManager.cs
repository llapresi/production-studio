﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGameManager : MonoBehaviour {

    private bool backgroundIn;

    // Use this for initialization
    void Start() {
        backgroundIn = false;
    }

    // Update is called once per frame
    void Update() {

    }

    public bool BackGroundIn
    {
        get
        {
            return backgroundIn;
        }
        set
        {
            backgroundIn = value;
        }
    }
}
