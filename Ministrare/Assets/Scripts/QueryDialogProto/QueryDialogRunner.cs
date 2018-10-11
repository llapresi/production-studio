using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

// Runs through a dialog script
// This class should really be split into into two eventually
// One that handles loading the files, "running through it" and doing DialogNodeActions, and another that handles setting the UI
public class QueryDialogRunner : MonoBehaviour
{
    // Stores our current node
    DialogNode currentDialogNode;

    // UI Elements
    public TextMeshProUGUI dialogDisplay;
    public UIDialogButton[] choiceButtons;

    // Dialog tree our runner is running
    DialogQuery query;

    // Test to update the GUI
    public UnityEvent updateGUI;

    // Use this for initialization
    void Start()
    {
        //Created hardcoded query data
        query = new DialogQuery();
        query.topics.Add(new DialogQueryTopic("test subject"));
        query.topics[0].conversations.Add(new TreeWithId("test convo"));
        query.topics[0].GetDialogTreeForId("test convo").dialogNodes.Add(new DialogNode("This is a test response for conversation 'testconvo'", null, null));
        query.topics[0].conversations.Add(new TreeWithId("test convo 2"));
        query.topics[0].GetDialogTreeForId("test convo 2").dialogNodes.Add(new DialogNode("This is a another test response for conversation 'testconvo2", null, null));
    }

    void SetCurrentNode(DialogNode newDialogNode)
    {
        currentDialogNode = newDialogNode;
        dialogDisplay.text = currentDialogNode.dialogText;
        updateGUI.Invoke();
    }

    // Bad hardcoded functions
    // Using this for milestone 1 showcase

    public void GoToTestConvoWithName(string name)
    {
        SetCurrentNode(query.topics[0].GetDialogTreeForId(name).dialogNodes[0]);
    }
}
