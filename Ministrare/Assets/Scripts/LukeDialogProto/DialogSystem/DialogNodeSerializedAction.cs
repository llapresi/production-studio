using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C# class representing the serialized form of a dialog action. We can't serialize the main class because
// JsonUtility doesn't support serializing an array of an abstract class/interface in the DialogNode so we serialize these instead

[System.Serializable]
class DialogNodeSerializedAction
{
    public string actionType;
    public string actionParams;

    public DialogNodeSerializedAction(string p_actionType, string p_actionParams)
    {
        actionType = p_actionType;
        actionParams = p_actionParams;
    }
}

