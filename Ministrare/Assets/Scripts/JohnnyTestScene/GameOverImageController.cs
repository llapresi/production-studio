﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameOverImageController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject GO1 = GameObject.Find("GameManager");
        GameManager GM = GO1.GetComponent<GameManager>();
        string imageName = "Assets/Images/Backgrounds/" +GM.Ending;
        Sprite endingSprite = AssetDatabase.LoadAssetAtPath<Sprite>(imageName);
        GameObject GO2 = GameObject.Find("GameOverScreen");
        Image image = GO2.GetComponent<Image>();
        image.sprite = endingSprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}