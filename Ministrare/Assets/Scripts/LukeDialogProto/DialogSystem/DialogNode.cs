using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A node contains the text for the given dialog piece, any preconditions needed to access this link
// any actions that happen upon this node being opened, and a list of branches this node can go to
// The nextNode array stores array of DialogNodeLinks
[System.Serializable]
public class DialogNode: ISerializationCallbackReceiver
{
    // The text of this dialogNode
    public string dialogText;
    // Choices for possible next nodes
    public DialogNodeLink[] nextNodes;
    // Seralized form of actions that occur on node load
    public DialogNodeSerializedAction[] serializedActions;
    // Unseralized form of actions that occur on node load
    public IDialogNodeAction[] actions;

    public DialogNode(string p_dialogText, DialogNodeLink[] p_nextNodes, IDialogNodeAction[] p_nodeActions = null)
    {
        dialogText = p_dialogText;
        nextNodes = p_nextNodes;
        actions = p_nodeActions;
    }

    public void OnAfterDeserialize()
    {
        if(serializedActions != null)
        {
            
            actions = new IDialogNodeAction[serializedActions.Length];
            for (int i = 0; i < serializedActions.Length; i++)
            {
                Debug.Log(serializedActions[i].actionType);
                if (serializedActions[i].actionType == "modifyStats")
                {
                    var newAction = new ModifyStatsDialogNodeAction("whatever", 0);
                    newAction.FromSerializedAction(serializedActions[i]);
                    actions[i] = newAction;
                }
            }
        }
    }

    public void OnBeforeSerialize()
    {

    }
}