using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ministrare.UI
{
    // MonoBehaviour attached to CanvasPauseMenu parent in the pause menu scene
    public class UIPauseMenu : MonoBehaviour {

        // Timer singleton var, used to pause the game when the time is open
        public TimerTime gameTime;

	    // Use this for initialization
	    void Start () {
            // Pause the timer when the pause menu is loaded
            gameTime.paused = true;
        }

        // Called when the pause menu is closed
	    public void Exit()
        {
            StartCoroutine(UnloadPauseMenu());
        }

        IEnumerator UnloadPauseMenu()
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(gameObject.scene);

            // Wait until the asynchronous scene fully loads
            while (!asyncUnload.isDone)
            {
                yield return null;
            }
        }

        void OnDestroy()
        {
            gameTime.paused = false;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Exit();
            }
        }
    }
}
