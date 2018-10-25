using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

// Extends QueryDialogRunner, adds shit to save and load JSON files
// plus hooks for UI scene to let you add stuff to the currentQuery
public class QueryDialogEditor : QueryDialogRunner
{
    // Stores current/last selected QueryDialogTopic
    DialogQueryTopic currentDialogTopic = null;

    public TMP_InputField dialogInput;

    protected override void Start()
    {
        base.Start();
    }

    public void SaveJSON()
    {
        // Right now we're just exporting to the console
        // Should read this page in the documentation on how to actually make this save a file
        //https://support.unity3d.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
        Debug.Log(JsonUtility.ToJson(currentQuery));
    }

    public void SetCurrentDialogTopic(DialogQueryTopic p_topic = null)
    {
        currentDialogTopic = p_topic;
    }

    public override void SetCurrentNode(DialogNode newDialogNode)
    {
        currentDialogNode = newDialogNode;
        dialogInput.text = currentDialogNode.dialogText;
        updateGUI.Invoke();
    }

    public void ChangeCurrentNode()
    {
        // Text Editor UI calls this whenever user types to set the currentDialogNode text to the input
        currentDialogNode.dialogText = dialogInput.text;
    }

    public void HandleAddButton()
    {
        if(currentDialogTopic != null)
        {
            // If we have a QueryTopic opened, add a new DialogTreeWithId to it when we press this button
            currentDialogTopic.conversations.Add(new DialogTreeWithId("New tree"));
        }
        else
        {
            // If we don't, lets make a new QueryTopic
            currentQuery.topics.Add(new DialogQueryTopic("new query topic"));
        }
    }
}
