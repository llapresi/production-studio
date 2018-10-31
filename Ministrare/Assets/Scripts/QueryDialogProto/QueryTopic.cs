using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains a list of DialogTrees for a given topic
// this stores all the dialogs for "what is your RELATIONSHIP with another leader" stuff
[System.Serializable]
public class DialogQueryTopic : IEditorRenamable, IEditorAddable
{
    public string identifier;
    public List<DialogTreeWithId> conversations;

    public DialogTree GetDialogTreeForId(string id)
    {
        foreach (DialogTreeWithId convo in conversations)
        {
            if (convo.identifier == id)
            {
                return convo;
            }
        }
        return null;
    }

    public string GetName()
    {
        return identifier;
    }

    public void SetName(string newName)
    {
        identifier = newName;
    }

    public void Add(string nameOfElementToAdd)
    {
        conversations.Add(new DialogTreeWithId(nameOfElementToAdd));
    }

    public DialogQueryTopic(string p_id)
    {
        identifier = p_id;
        conversations = new List<DialogTreeWithId>();
    }
}

// Gives each dialogTree an id to identify itself by in a QueryTopic
[System.Serializable]
public class DialogTreeWithId : DialogTree, IEditorRenamable
{
    public string identifier;

    public DialogTreeWithId(string p_id) : base()
    {
        identifier = p_id;
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