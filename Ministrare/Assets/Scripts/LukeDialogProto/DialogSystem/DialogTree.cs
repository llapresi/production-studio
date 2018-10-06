using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basically just a list of dialogNodes. Stored as a class for serialization.
// Probably gonna have to add variables and other shit later but hopefully we should try to keep that stuff out of here
[System.Serializable]
class DialogTree
{
    public List<DialogNode> dialogNodes;

    public DialogTree()
    {
        dialogNodes = new List<DialogNode>();
    }
}