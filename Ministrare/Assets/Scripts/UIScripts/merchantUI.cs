﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class merchantUI : MonoBehaviour {


    //Canvas used for pause screen
    public Canvas pauseCanvas;


    // Use this for initialization
    void Start()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Pauses the game
        if (pauseCanvas != null)
        {


            if (Input.GetKeyDown("escape"))
            {
                if (pauseCanvas.enabled)
                {
                    pauseCanvas.enabled = false;
                }
                else
                {
                    pauseCanvas.enabled = true;
                }
            }

        }
    }


    //used for loading JSON
    public NextJSONToLoad paramObj;

    public string sceneToLoad;

    /// <summary>
    /// Loads conversation scenes with appropriate dialogue
    /// </summary>
    /// <param name="dialogue"></param>
    /// <param name="level"></param>
    public void LoadConvoScene(string dialogue)
    {
        //  set param stuff first
        if (paramObj != null)
        {
            paramObj.runtimeDialogPath = dialogue;
        }
        //StartCoroutine(LoadAsyncScene());
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Loads a scene additively
    /// </summary>
    /// <param name="level"></param>
    public void Load(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }

    /// <summary>
    /// Loads a scene non additively
    /// </summary>
    /// <param name="scene"></param>
    public void NewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    /// <summary>
    /// Removes an additevely loaded scene by destroying all objects from that scenes root
    /// </summary>
    /// <param name="root"></param>
    public void UnLoad(GameObject root)
    {
        Destroy(root);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

}
