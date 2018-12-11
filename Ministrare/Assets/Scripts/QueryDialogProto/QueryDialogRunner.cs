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

    // Use this component to set the images based on the dialog file
    public UISetDialogImages setDialogImages;

    public NPCandLordHolder nPCandLordHolder;

    // Use this for initialization
    protected virtual void Start()
    {
        // Load our test JSON dialogQuery
        TextAsset targetFile = Resources.Load<TextAsset>(dialogToLoad.runtimeDialogPath);
        currentQuery = JsonUtility.FromJson<DialogQuery>(targetFile.text);

        buttonGroup.InitButtonGroup(this);
        if(setDialogImages != null)
        {
            setDialogImages.SetBackground(currentQuery.leaderID);
        }
        startingText();
    }

    public virtual void SetCurrentNode(DialogNode newDialogNode)
    {
        currentDialogNode = newDialogNode;
        dialogDisplay.text = currentDialogNode.dialogText;
        updateGUI.Invoke();
        RunNodeActions(newDialogNode);
    }

    public void startingText()
    {
        GameObject GO = GameObject.Find("DialogText");
        TextMeshProUGUI textmesh = GO.GetComponent<TextMeshProUGUI>();
        if (currentQuery.leaderID == "allyFarmer")
        {
            textmesh.text = "FARMER LEADER: How can I help you, my leige?";
        }
        if (currentQuery.leaderID == "allyMerchant")
        {
            textmesh.text = "MERCHANT LEADER: How can I help you, my leige?";
        }
        if (currentQuery.leaderID == "allyMilitary")
        {
            textmesh.text = "MILITARY LEADER: How can I help you, my leige?";
        }
        if (currentQuery.leaderID == "allyScholar")
        {
            textmesh.text = "SCHOLAR LEADER: How can I help you, my leige?";
        }
        if (currentQuery.leaderID == "allySmith")
        {
            textmesh.text = "SMITH LEADER: How can I help you, my leige?";
        }
    }

    void RunNodeActions(DialogNode newDialogNode)
    {
        // Check through node actions
        if (newDialogNode.actions != null)
        {
            foreach (IDialogNodeAction action in newDialogNode.actions)
            {
                // Need a more elegant way of getting the type
                if (action.GetType() == typeof(ModifyStatsDialogNodeAction))
                {
                    var statAction = action as ModifyStatsDialogNodeAction;
                    
                    // Using reflection to set the leader values.
                    // This is a really bad and confusing way of doing this but hey, one week and I don't wanna touch the data model at this point

                    // This is the actual leader object
                    var leaderObj = nPCandLordHolder.leaderIDPairs[currentQuery.leaderID];

                    // This is the property we're changing (ex. happiness, fear, etc) gotten by the name in the JSON file
                    var relevantProp = leaderObj.GetType().GetProperty(statAction.statName);

                    // Get the existing value and change it
                    int existingValue = (int)relevantProp.GetValue(leaderObj, null);
                    existingValue += statAction.statChangeValue;

                    // Set it in the object and print the new file
                    relevantProp.SetValue(leaderObj, existingValue, null);
                    Debug.Log(statAction.statName + " is now " + relevantProp.GetValue(leaderObj, null));
                }
            }
        }
    }

    // Bad hardcoded functions
    // Using this for milestone 1 showcase

    public void GoToTestConvoWithName(string name)
    {
        SetCurrentNode(currentQuery.topics[0].GetDialogTreeForId(name).dialogNodes[0]);
    }
}
