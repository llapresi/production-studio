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

    public string filepath;

    // Use this for initialization
    void Start()
    {
        // Load our test JSON dialogQuery
        TextAsset targetFile = Resources.Load<TextAsset>(filepath);
        currentQuery = JsonUtility.FromJson<DialogQuery>(targetFile.text);

        buttonGroup.rootQuery = currentQuery;
        buttonGroup.CreateRootButtons();
    }

    public void SetCurrentNode(DialogNode newDialogNode)
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
