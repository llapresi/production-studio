using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains a list of DialogTrees for a given topic
// this stores all the dialogs for "what is your RELATIONSHIP with another leader" stuff
[System.Serializable]
class DialogQueryTopic
{
    public string identifier;
    public List<TreeWithId> conversations;

    public DialogTree GetDialogTreeForId(string id)
    {
        foreach (TreeWithId convo in conversations)
        {
            if (convo.identifier == id)
            {
                return convo.dialogTree;
            }
        }
        return null;
    }

    public DialogQueryTopic(string p_id)
    {
        identifier = p_id;
        conversations = new List<TreeWithId>();
    }
}

// Gives each dialogTree an id to identify itself by in a QueryTopic
[System.Serializable]
class TreeWithId
{
    public string identifier;
    public DialogTree dialogTree;

    public TreeWithId(string p_id)
    {
        dialogTree = new DialogTree();
        identifier = p_id;
    }
}