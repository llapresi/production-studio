using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

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
        // changes text to say you lose or you win
        GameObject GO3 = GameObject.Find("GameOverStatement");
        TextMeshProUGUI textMesh = GO3.GetComponent<TextMeshProUGUI>();
        if(GM.Ending.Contains("Win"))
        {
            textMesh.text = "You Win";
        }
        else
        {
            textMesh.text = "You Lose";
        }
        // hides timer // very hacky
        TimerTime timerTime = (TimerTime)AssetDatabase.LoadAssetAtPath("Assets/_SingletonVars/TestTimerTime.asset", typeof(TimerTime));
        timerTime.paused = true;
        GameObject TimerCanvas = GameObject.Find("TimerCanvas");
        TimerCanvas.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
