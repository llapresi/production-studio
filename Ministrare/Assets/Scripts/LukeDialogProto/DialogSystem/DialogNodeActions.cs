using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# abstract class for a dialog action. This could be anything from shaking the screen upon dialog node opening
// to changing player staistics
interface IDialogNodeAction
{
    DialogNodeSerializedAction ToSerializedAction();
    void FromSerializedAction(DialogNodeSerializedAction serializedAction);
}

// Class that contains the name of a statistic and 
[System.Serializable]
class ModifyStatsDialogNodeAction: IDialogNodeAction
{
    public string statName;
    public int statChangeValue;

    public ModifyStatsDialogNodeAction(string p_statName, int p_statChangeValue)
    {
        statName = p_statName;
        statChangeValue = p_statChangeValue;
    }

    public DialogNodeSerializedAction ToSerializedAction()
    {
        return new DialogNodeSerializedAction("modifyStats", statName + " " + statChangeValue.ToString());
    }

    public void FromSerializedAction(DialogNodeSerializedAction serializedAction)
    {
        if(serializedAction.actionType == "modifyStats")
        {
            string[] actionParams = serializedAction.actionParams.Split(' ');
            statName = actionParams[0];
            statChangeValue = int.Parse(actionParams[1]);
        }
        else
        {
            Debug.LogError("passed non 'modifyStats object into ModifyStatsDialogNodeAction.FromSerializedAction");
        }
    }
}