using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool backgroundIn;
    [SerializeField]
    private NPCandLordHolder NPCLordHolder;
    // Use this for initialization
    void Start()
    {
        NPCLordHolder.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
