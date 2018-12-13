using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class GameOverImageController : MonoBehaviour {

    public List<Sprite> endingSprites = new List<Sprite>();

	// Use this for initialization
	void Start () {
        GameObject GO1 = GameObject.Find("GameManager");
        GameManager GM = GO1.GetComponent<GameManager>();
        //string imageName = "Assets/Images/Backgrounds/" +GM.Ending;
        //Sprite endingSprite = AssetDatabase.LoadAssetAtPath<Sprite>(imageName);
        Sprite endingSprite = null;
        for (int x = 0; x < endingSprites.Count; x++)
        {
            Sprite sprite = endingSprites[x];
            if (sprite.name == GM.Ending)
            {
                endingSprite = sprite;
            }
        }
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
        GameObject GO = GameObject.Find("Timer");
        TimerRunner timerRunner = GO.GetComponent<TimerRunner>();
        TimerTime timerTime = timerRunner.time;
        timerTime.paused = true;
        GameObject TimerCanvas = GameObject.Find("TimerCanvas");
        TimerCanvas.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
