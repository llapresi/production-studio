using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ScriptableObject that holds a path for the next JSON file to load
// Ideal Usage: Create a component called "Dialog Link" or something like that
// You attach this to a button, is has "Scene", "Dialog Path", and "NextJSONToLoad" public fields
// When you click the button, is sets the NextJSONToLoad's "path" variable to the "Dialog Path" variable
// Then the DialogScene reads this NextJSONToLoad SingletonVar and loads the corresponding JSON dialog script
[CreateAssetMenu(fileName = "New NextJSONToLoad", menuName = "Ministrare/SingletonVars/NextJSONToLoad", order = 1)]
public class NextJSONToLoad : ScriptableObject
{
    [Header("Initial Values")]
    [SerializeField]
    private string dialogPath;
    [Space(3)]
    [Header("Runtime Values [No Touchy]")]
    public string runtimeDialogPath;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        runtimeDialogPath = dialogPath;
    }
}