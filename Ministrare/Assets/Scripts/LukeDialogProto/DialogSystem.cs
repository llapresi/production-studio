using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A node contains the text for the given dialog piece, and a list of branches this node can go to
// The nextNode array stores array of NextNodeLinks
[System.Serializable]
class DialogNode
{
    public string dialogText;
    public NextNodeLink[] nextNodes;

    public DialogNode(string p_dialogText, NextNodeLink[] p_nextNodes)
    {
        dialogText = p_dialogText;
        nextNodes = p_nextNodes;
    }
}

// NextNodeLink contains the indicie of the next dialog node (according to the list it's stored in)
// and a 'displayText' field that dictates what the button name for this option should be on the dialog screen
[System.Serializable]
class NextNodeLink
{
    public int id;
    public string displayText;

    public NextNodeLink(int p_id, string p_displayText)
    {
        id = p_id;
        displayText = p_displayText;
    }
}

// Basically just a list of dialogNodes. Stored as a class for serialization.
// Probably gonna have to add variables and other shit later
[System.Serializable]
class DialogTree
{
    public List<DialogNode> dialogNodes;

    public DialogTree()
    {
        dialogNodes = new List<DialogNode>();
    }
}
