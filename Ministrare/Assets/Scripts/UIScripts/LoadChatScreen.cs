using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    private bool paused;
    public GameObject canvas;

	// Use this for initialization
	void Start ()
    {
        paused = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (!paused)
            {
                canvas.gameObject.SetActive(true);
                paused = true;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                paused = false;
            }
        }
	}

    public void Load(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }
}
