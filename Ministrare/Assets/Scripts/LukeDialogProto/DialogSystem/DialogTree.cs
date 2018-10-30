using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Basically just a list of dialogNodes. Stored as a class for serialization.
// Probably gonna have to add variables and other stuff later but hopefully we should try to keep that stuff out of here
[System.Serializable]
public class DialogTree: IEditorAddable
{
    public List<DialogNodeWithID> dialogNodes;

    public DialogTree()
    {
        dialogNodes = new List<DialogNodeWithID>();
    }

    public void Add(string nameOfElementToAdd)
    {
        dialogNodes.Add(new DialogNodeWithID(nameOfElementToAdd, "", null, null));
    }
}

[System.Serializable]
public class DialogNodeWithID : DialogNode, IEditorRenamable
{
    public string identifier;

    public DialogNodeWithID(string p_identifier, string p_dialogText, DialogNodeLink[] p_nextNodes, IDialogNodeAction[] p_nodeActions = null) 
        : base(p_dialogText, p_nextNodes, p_nodeActions)
    {
        identifier = p_identifier;
    }

    public string GetName()
    {
        return identifier;
    }

    public void SetName(string newName)
    {
        identifier = newName;
    }
}