using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLink : MonoBehaviour {

    // Name of scene to load
    public string sceneName;
    // This is going to point to a static class that we'll use to set things like what JSON file to load
    public string sceneParams;

	public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
