using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool backgroundIn;
    private static bool created = false;
    [SerializeField]
    private NPCandLordHolder NPCLordHolder;
    // Use this for initialization
    void Start()
    {
        if(!created)
        {
            NPCLordHolder.Initialize();
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
