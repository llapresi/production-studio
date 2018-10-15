using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

// Runs throughshould a dialog script
// This class  really be split into into two eventually
// One that handles loading the files, "running through it" and doing DialogNodeActions, and another that handles setting the UI
public class QueryDialogRunner : MonoBehaviour
{
    // Stores our current node
    DialogNode currentDialogNode;

    // UI Elements
    public TextMeshProUGUI dialogDisplay;
    public UIDialogButton[] choiceButtons;

    // Dialog tree our runner is running
    public DialogQuery currentQuery;

    // Test to update the GUI
    public UnityEvent updateGUI;

    public UIQueryButtonGroup buttonGroup;

    // Use this for initialization
    void Start()
    {
        //Created hardcoded query data
        currentQuery = new DialogQuery();
        currentQuery.topics.Add(new DialogQueryTopic("test topic"));
        currentQuery.topics[0].conversations.Add(new DialogTreeWithId("test convo"));
        currentQuery.topics[0].GetDialogTreeForId("test convo").dialogNodes.Add(new DialogNode("This is a test response for conversation 'testconvo'", null, null));
        currentQuery.topics[0].conversations.Add(new DialogTreeWithId("test convo 2"));
        currentQuery.topics[0].GetDialogTreeForId("test convo 2").dialogNodes.Add(new DialogNode("This is a another test response for conversation 'testconvo2", null, null));
        currentQuery.topics.Add(new DialogQueryTopic("another test topic"));
        currentQuery.topics[1].conversations.Add(new DialogTreeWithId("test convo 3"));
        currentQuery.topics[1].GetDialogTreeForId("test convo 3").dialogNodes.Add(new DialogNode("This is a test response for conversation 'testconvo'", null, null));
        currentQuery.topics[1].conversations.Add(new DialogTreeWithId("test convo 4"));
        currentQuery.topics[1].GetDialogTreeForId("test convo 4").dialogNodes.Add(new DialogNode("This is a another test response for conversation 'testconvo2", null, null));

        buttonGroup.rootQuery = currentQuery;
        buttonGroup.CreateRootButtons();
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
        SetCurrentNode(currentQuery.topics[0].GetDialogTreeForId(name).dialogNodes[0]);
    }
}
