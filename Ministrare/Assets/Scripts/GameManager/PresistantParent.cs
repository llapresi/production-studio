using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresistantParent : MonoBehaviour {

    private static bool created = false;

    // Use this for initialization
    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
