using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// A node contains the text for the given dialog piece, and a list of branches this node can go to
[System.Serializable]
class DialogNode
{
    public string dialogText;
    public int nextNodeIndex;

    public DialogNode(string p_dialogText, int p_nextNodeIndex)
    {
        dialogText = p_dialogText;
        nextNodeIndex = p_nextNodeIndex;
    }
}

// Basically just a list of dialogNodes. Stored as a class for serialization. Will probably do more stuff later
// This will probably be changed to a LinkedList or something similar to make the node linking/indice confusing not be a thing
[System.Serializable]
class DialogTree
{
    public List<DialogNode> dialogNodes;

    public DialogTree()
    {
        dialogNodes = new List<DialogNode>();
    }
}

public class DialogRunner : MonoBehaviour {
    // Stores our current node
    DialogNode currentDialogNode;

    // UI Element 
    public TextMeshProUGUI dialogDisplay;

    // Dialog list
    DialogTree dialogTree;

    // Use this for initialization
    void Start () {
        // Lets add some test data
        dialogTree = new DialogTree();
        dialogTree.dialogNodes.Add(new DialogNode("The first node", 1));
        dialogTree.dialogNodes.Add(new DialogNode("The sceond node", 2));
        dialogTree.dialogNodes.Add(new DialogNode("The third node", 0));

        Debug.Log(JsonUtility.ToJson(dialogTree));

        SetCurrentNode(0);
    }

    void SetCurrentNode(int newNodeIndex)
    {
        currentDialogNode = dialogTree.dialogNodes[newNodeIndex];
        dialogDisplay.text = currentDialogNode.dialogText;
    }

    public void GoToNextNode()
    {
        SetCurrentNode(currentDialogNode.nextNodeIndex);
    }
}
