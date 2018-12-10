using Ministrare.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UItest : MonoBehaviour
{

    //Canvas used for pause screen
    public Canvas pauseCanvas;
    public TimerTime time;

    // Use this for initialization
    void Start()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.enabled = false;
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

    public void resetandLoad(string scene)
    {
        //Try to reset everything
        if (GameObject.Find("PresistantParent") != null)
        {
            GameObject PP = GameObject.Find("PresistantParent");
            PresistantParent presistantParent = PP.GetComponent<PresistantParent>();
            presistantParent.SetTimerCanvasActive();
            MinistrareEventRunner ministrareEventRunner = PP.GetComponentInChildren<MinistrareEventRunner>();
            ministrareEventRunner.Reset();
            Military military = (Military)AssetDatabase.LoadAssetAtPath("Assets/_SingletonVars/Military.asset", typeof(Military));
            ResourceManager resourceManager = (ResourceManager)AssetDatabase.LoadAssetAtPath("Assets/_SingletonVars/ResourceManager.asset", typeof(ResourceManager));
            TimerTime time = (TimerTime)AssetDatabase.LoadAssetAtPath("Assets/_SingletonVars/TestTimerTime.asset", typeof(TimerTime));
            NPCandLordHolder nPCandLordHolder = (NPCandLordHolder)AssetDatabase.LoadAssetAtPath("Assets/_SingletonVars/NPCandLordHolder.asset", typeof(NPCandLordHolder));
            time.Reset();
            resourceManager.Reset();
            military.Reset();
            nPCandLordHolder.Initialize();
        }
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
