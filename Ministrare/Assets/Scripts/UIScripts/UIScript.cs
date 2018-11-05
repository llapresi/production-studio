using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadChatScreen : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("PauseMenuUI", LoadSceneMode.Additive);
        }
	}

    public void Load(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }
}
