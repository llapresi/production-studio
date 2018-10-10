using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ScriptableObject that holds statistcs values for the player (and possibly the AI)
// These are just example values in here right now
// ISerializationCallbackReceiver is used to prevent values changed during Play Mode from changing asset properties (in-editor)
// (ex. saving and loading can be done by just seralizing this object and setting the privates to the runtimes)
[CreateAssetMenu(fileName = "New PlayerStatsObject", menuName = "Ministrare/Player Stats Object", order = 1)]
public class PlayerStatsObject : ScriptableObject
{
    [SerializeField]
    private int inteligence = 0;
    [SerializeField]
    private int persuasion = 0;
    [SerializeField]
    private int fear = 0;

    public int runtimeInteligence;
    public int runtimePersuasion;
    public int runtimeFear;

    public void OnEnable()
    {
        runtimeInteligence = inteligence;
        runtimePersuasion = persuasion;
        runtimeFear = fear;
        Debug.Log("PlayerStatsObject reset");
    }

    public void OnBeforeSerialize()
    {
        
    }
}