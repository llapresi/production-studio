using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneLink : MonoBehaviour {

    // Name of scene to load
    public string sceneName;
    // This is going to point to a static class that we'll use to set things like what JSON file to load
    public string dialogPathToLoad;
    // SingletonVar that will be passed into the next scene. FWIW only dialog scenes are using this rn but we're probably going to have to
    // create a way to either extend this later
    // OR we're not gonna be using this once we have your leader entites set up
    public NextJSONToLoad paramObj;

	public void LoadScene()
    {
        //  set param stuff first
        if(paramObj != null)
        {
            paramObj.runtimeDialogPath = dialogPathToLoad;
        }
        // set military off screen locations
        GameObject GO = GameObject.Find("GameManager");
        GameManager GM = GO.GetComponent<GameManager>();
        Military military = GM.military;
        military.saveOffScreenPos();
        //StartCoroutine(LoadAsyncScene());
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    IEnumerator LoadAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
