using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UItest : MonoBehaviour
{

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

    public void Load(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }

    //loads scene nonadditively
    public void NewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void UnLoad(GameObject root)
    {
        Destroy(root);
    }

}
