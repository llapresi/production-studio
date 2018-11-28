using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.IO;
using System;

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

    public UISetLeaderIDPanel leaderIDPanel;

    public string editorDialogPath;

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
        // overriding to not use the dialogToLoad ScriptableObject and use a text path instead
        // Load our test JSON dialogQuery
        TextAsset targetFile = Resources.Load<TextAsset>(editorDialogPath);
        currentQuery = JsonUtility.FromJson<DialogQuery>(targetFile.text);

        buttonGroup.InitButtonGroup(this);
        leaderIDPanel.Setup(this);
    }

    public void RenameDialogTopic(string newName)
    {
        lastSelectedRenamable.SetName(newName);
    }

    public void RefreshButtons()
    {
        refreshButtonMethod();
    }

    public void SaveJSON()
    {
        string path = null;
#if UNITY_EDITOR
        path = string.Format("Assets/Resources/{0}.json", editorDialogPath);
#endif

        // Don't run this in a standalone build
        if(path == null)
        {
            return;
        }

        string str = JsonUtility.ToJson(currentQuery);
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(str);
            }
        }
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
        Debug.Log(string.Format("file saved to {0}", path));
#endif
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

    public void SetLeaderID(string text)
    {
        currentQuery.leaderID = text;
    }
}
