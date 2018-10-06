using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# interface for a dialog action. This could be anything from shaking the screen upon dialog node opening
// to changing player staistics
[System.Serializable]
abstract class DialogNodeAction
{
    abstract public void RunAction();
}

// Class that contains the name of a statistic and 
[System.Serializable]
class ModifyStatsDialogNodeAction: DialogNodeAction
{
    public string statName;
    public int statChangeValue;

    public ModifyStatsDialogNodeAction(string p_statName, int p_statChangeValue)
    {
        statName = p_statName;
        statChangeValue = p_statChangeValue;
    }

    public override void RunAction()
    {
        Debug.Log(statName);
    }
}