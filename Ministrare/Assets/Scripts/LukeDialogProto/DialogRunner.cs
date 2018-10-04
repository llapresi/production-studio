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
    public UIDialogButton[] choiceButtons;

    // Dialog tree our runner is running
    DialogTree dialogTree;

    // Use this for initialization
    void Start () {
        // Load our test JSON dialog
        string filepath = "Dialog/testScript";
        TextAsset targetFile = Resources.Load<TextAsset>(filepath);
        dialogTree = JsonUtility.FromJson<DialogTree>(targetFile.text);

        // Set up UI buttons
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            int buttonIndex = i;
            choiceButtons[buttonIndex].button.onClick.AddListener(() => GoToNextNode(buttonIndex));
        }

        SetCurrentNode(0);
    }

    void SetCurrentNode(int newNodeIndex)
    {
        // Load Next Node
        currentDialogNode = dialogTree.dialogNodes[newNodeIndex];
        // Set dialog text
        dialogDisplay.text = currentDialogNode.dialogText;
        // Refresh buttons ui
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < currentDialogNode.nextNodes.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(true);
            choiceButtons[i].text.text = currentDialogNode.nextNodes[i].displayText;
        }
    }

    void GoToNextNode(int nextNodeIndex)
    {
        SetCurrentNode(currentDialogNode.nextNodes[nextNodeIndex].id);
    }
}
