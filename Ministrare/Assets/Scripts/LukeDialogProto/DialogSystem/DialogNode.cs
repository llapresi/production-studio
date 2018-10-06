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
    // Actions that occur on node load
    // SHITTY HACK ALERT: An idea implementation would use a single array of a "DialogNodeAction" interface or abstract class
    // but because the JsonUtility does not support polymorphism we're gonna store an array of each node action type
    // for now. Quickest and easiest solution is to replace JsonUtility with OdinSeralizer (which is open source under Apache so it should be fine)
    // but I don't wanna risk breaking anything for Milestone 1 just yet
    public ModifyStatsDialogNodeAction[] statActions;

    public DialogNode(string p_dialogText, DialogNodeLink[] p_nextNodes, ModifyStatsDialogNodeAction[] p_nodeActions = null)
    {
        dialogText = p_dialogText;
        nextNodes = p_nextNodes;
        statActions = p_nodeActions;
    }
}