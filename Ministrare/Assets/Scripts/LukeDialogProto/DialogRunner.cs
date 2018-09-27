using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Runs through a dialog script
// This class should really be split into into two eventually
// One that handles loading the files and "running through it", and another that handles setting the UI shit
public class DialogRunner : MonoBehaviour {
    // Stores our current node
    DialogNode currentDialogNode;

    // UI Elements
    public TextMeshProUGUI dialogDisplay;
    public UnityEngine.UI.Button choice1button;
    public UnityEngine.UI.Button choice2button;

    // Dialog tree our runner is running
    DialogTree dialogTree;

    // Use this for initialization
    void Start () {
        // Load our test JSON dialog
        string filepath = "Dialog/testScript";
        TextAsset targetFile = Resources.Load<TextAsset>(filepath);
        dialogTree = JsonUtility.FromJson<DialogTree>(targetFile.text);

        // Set up UI buttons
        choice1button.onClick.AddListener(() => GoToNextNode(0));
        choice2button.onClick.AddListener(() => GoToNextNode(1));

        SetCurrentNode(0);
        Debug.Log(JsonUtility.ToJson(dialogTree));
    }

    void SetCurrentNode(int newNodeIndex)
    {
        currentDialogNode = dialogTree.dialogNodes[newNodeIndex];
        dialogDisplay.text = currentDialogNode.dialogText;
    }

    void GoToNextNode(int nextNodeIndex)
    {
        SetCurrentNode(currentDialogNode.nextNodes[nextNodeIndex]);
    }
}
