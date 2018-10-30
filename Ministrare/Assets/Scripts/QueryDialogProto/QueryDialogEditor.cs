using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public delegate void RefreshButtonsDelegate();

// Extends QueryDialogRunner, adds shit to save and load JSON files
// plus hooks for UI scene to let you add stuff to the currentQuery
public class QueryDialogEditor : QueryDialogRunner
{
    // Input field in the scene
    public TMP_InputField dialogInput;

    public IEditorRenamable lastSelectedRenamable;
    public IEditorAddable lastSelectedAddable;

    public UnityEvent onSelect;

    public RefreshButtonsDelegate refreshButtonMethod;
    public TextMeshProUGUI pathDisplay;

    public string CurrentPath
    {
        get
        {
            return pathDisplay.text;
        }

        set
        {
            pathDisplay.text = value;
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    public void RenameDialogTopic(string newName)
    {
        lastSelectedRenamable.SetName(newName);
    }

    public void SaveJSON()
    {
        // Right now we're just exporting to the console
        // Should read this page in the documentation on how to actually make this save a file
        // https://support.unity3d.com/hc/en-us/articles/115000341143-How-do-I-read-and-write-data-from-a-text-file-
        Debug.Log(JsonUtility.ToJson(currentQuery));
    }

    // Overrides 'SetCurrentNode' from QueryDialogRunner to set the text of the dialogInput instead of the
    // textdisplay
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

    public void HandleAddButton(string newElementName = "New item")
    {
        lastSelectedAddable.Add(newElementName);
        refreshButtonMethod();
    }
}
