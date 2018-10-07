using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A node contains the text for the given dialog piece, any preconditions needed to access this link
// any actions that happen upon this node being opened, and a list of branches this node can go to
// The nextNode array stores array of DialogNodeLinks
[System.Serializable]
class DialogNode
{
    // The text of this dialogNode
    public string dialogText;
    // Choices for possible next nodes
    public DialogNodeLink[] nextNodes;
    // Seralized form of actions that occur on node load
    public ModifyStatsDialogNodeAction[] statActions;

    public DialogNode(string p_dialogText, DialogNodeLink[] p_nextNodes, ModifyStatsDialogNodeAction[] p_nodeActions = null)
    {
        dialogText = p_dialogText;
        nextNodes = p_nextNodes;
        statActions = p_nodeActions;
    }
}