using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

// Runs through a dialog script
// This class should really be split into into two eventually
// One that handles loading the files, "running through it" and doing DialogNodeActions, and another that handles setting the UI shit
public class DialogRunner : MonoBehaviour {
    // Stores our current node
    DialogNode currentDialogNode;

    // UI Elements
    public TextMeshProUGUI dialogDisplay;
    public UIDialogButton[] choiceButtons;

    // Dialog tree our runner is running
    DialogTree dialogTree;

    // JSON file containing our current dialog
    public string filepath;

    public PlayerStatsObject playerStats;

    // Test to update the GUI
    public UnityEvent updateGUI;

    // Use this for initialization
    void Start () {
        // Load our test JSON dialog
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
        // Execute dialog node actions
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

        // EXTREMLEY HACKY WAY OF APPLYING STATACTIONS.
        if (currentDialogNode.statActions != null)
        {
            for (int i = 0; i < currentDialogNode.statActions.Length; i++)
            {
                if (currentDialogNode.statActions[i].statName == "Fear")
                {
                    playerStats.runtimeFear += currentDialogNode.statActions[i].statChangeValue;
                }
                if (currentDialogNode.statActions[i].statName == "Intelligence")
                {
                    playerStats.runtimeInteligence += currentDialogNode.statActions[i].statChangeValue;
                }
                if (currentDialogNode.statActions[i].statName == "Persuasion")
                {
                    playerStats.runtimePersuasion += currentDialogNode.statActions[i].statChangeValue;
                }
            }
        }
        updateGUI.Invoke();
    }

    void GoToNextNode(int nextNodeIndex)
    {
        SetCurrentNode(currentDialogNode.nextNodes[nextNodeIndex].id);
    }
}
