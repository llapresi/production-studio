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
    protected DialogNode currentDialogNode;

    // UI Elements
    public TextMeshProUGUI dialogDisplay;

    // Dialog tree our runner is running
    public DialogQuery currentQuery;

    // Test to update the GUI
    public UnityEvent updateGUI;

    public BaseButtonGroup buttonGroup;

    // Set the value of the SingletonVar we're gonna plug in here before we load the Query Dialog Scene
    public NextJSONToLoad dialogToLoad;

    // Use this for initialization
    protected virtual void Start()
    {
        // Load our test JSON dialogQuery
        TextAsset targetFile = Resources.Load<TextAsset>(dialogToLoad.runtimeDialogPath);
        currentQuery = JsonUtility.FromJson<DialogQuery>(targetFile.text);

        buttonGroup.InitButtonGroup(this);
    }

    public virtual void SetCurrentNode(DialogNode newDialogNode)
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
