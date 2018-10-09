using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIExitButton : MonoBehaviour {

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
