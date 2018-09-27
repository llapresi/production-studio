using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A node contains the text for the given dialog piece, and a list of branches this node can go to
// The nextNode array stores indexes in an array
[System.Serializable]
class DialogNode
{
    public string dialogText;
    public int[] nextNodes;

    public DialogNode(string p_dialogText, int[] p_nextNodes)
    {
        dialogText = p_dialogText;
        nextNodes = p_nextNodes;
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
