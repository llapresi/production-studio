using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A ScriptableObject that holds raw JSON data. Used as a way to store JSON dynamically generated from a templace
// (ex. Spymaster dialog)
[CreateAssetMenu(fileName = "New GeneratedJSON", menuName = "Ministrare/SingletonVars/GeneratedJSON", order = 1)]
public class GeneratedJSON : ScriptableObject
{
    [Header("Initial Values")]
    [SerializeField]
    private string stringJSONValue;
    [Space(3)]
    [Header("Runtime Values [No Touchy]")]
    public string runtimeStringJSONValue;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        runtimeStringJSONValue = stringJSONValue;
    }
}