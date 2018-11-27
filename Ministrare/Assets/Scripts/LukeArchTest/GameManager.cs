using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool hasStarted = false;
    [SerializeField]
    private NPCandLordHolder NPCLordHolder;
    // Use this for initialization
    void Start()
    {
        if (hasStarted == false)
        {
            NPCLordHolder.Initialize();
            hasStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
