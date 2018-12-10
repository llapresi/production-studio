using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ministrare.UI
{
    public class UIPauseMenuHandler : MonoBehaviour {

        public string PauseScreenName;
	
	    // Update is called once per frame
	    void Update () {
            if(Input.GetKeyDown(KeyCode.Escape) && IsSceneLoaded(PauseScreenName) == false)
            {
                StartCoroutine(LoadScene());
            }
	    }

        // Returns true is the scene is already loaded so we don't load it twice
        bool IsSceneLoaded(string scenePath)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene iteratedScene = SceneManager.GetSceneAt(i);

                if (iteratedScene.name == PauseScreenName && iteratedScene.isLoaded == true)
                {
                    return true;
                }
            }
            return false;
        }

        IEnumerator LoadScene()
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(PauseScreenName, LoadSceneMode.Additive);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
