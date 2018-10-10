using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A ScriptableObject that holds statistcs values for the a "Leader" character
// You'd make one of these from the Assets -> Ministrare Menu for each Leader (so the player, each leader on your side and each enemy leader)
// We'll probably end up using one of these in a bigger "leader" ScriptableObject
// These are just example values in here right now
// HideFlags.DontUnloadUnusedAsset is used to prevent values changed during Play Mode from changing asset properties (in-editor)
[CreateAssetMenu(fileName = "New LeaderStatsObject", menuName = "Ministrare/SingletonVars/Leader Stats Object", order = 1)]
public class LeaderStatsObject : ScriptableObject
{
    [SerializeField]
    private int inteligence = 0;
    [SerializeField]
    private int persuasion = 0;
    [SerializeField]
    private int fear = 0;

    [System.NonSerialized]
    public int runtimeInteligence;
    [System.NonSerialized]
    public int runtimePersuasion;
    [System.NonSerialized]
    public int runtimeFear;

    public void OnEnable()
    {
        this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        runtimeInteligence = inteligence;
        runtimePersuasion = persuasion;
        runtimeFear = fear;
    }
}