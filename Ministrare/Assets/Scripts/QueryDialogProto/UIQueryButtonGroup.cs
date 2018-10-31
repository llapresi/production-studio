using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object that creates a bunch of Unity UI Buttons as it's childern
// Ideally you should be able to point a query dialog runner at it and it'll make the all
// the relevant buttons for it
public abstract class BaseButtonGroup: MonoBehaviour
{
    public abstract void InitButtonGroup(QueryDialogRunner setRunner);
    public abstract void CreateButtonsForTopic(DialogQueryTopic topic);
    public abstract void CreateRootButtons();
}

// Given the amount of changes that have happened under the hood
// I'm copy-pasting the editorbuttongroup now and removing all the editor
// specific stuff. TODO: Find a more elegant way to have the editorgroup build off the button group
public class UIQueryButtonGroup : BaseButtonGroup
{
    // Button prefab object
    public GameObject buttonPrefab;

    // ref to dialog query we're querying. This is set in QueryDialogRunner
    DialogQuery rootQuery;

    // ref to the current query
    QueryDialogRunner runner;

    // Use this for initialization
    public override void InitButtonGroup(QueryDialogRunner setRunner)
    {
        // Set the stuff
        runner = setRunner;
        rootQuery = setRunner.currentQuery;

        // Make our root level buttons
        CreateRootButtons();
    }

    public override void CreateRootButtons()
    {
        // Clear all the current buttons if they exist
        ClearButtons();

        // Create a button for each topic
        foreach (var queryTopic in rootQuery.topics)
        {
            // Create button prefab
            GameObject button = Instantiate(buttonPrefab) as GameObject;

            // Get the Button prefab with the remove button and their associated buttons
            var buttonComponent = button.GetComponent<UIDialogButton>();

            // Set button text and onClick's
            buttonComponent.text.text = queryTopic.identifier;
            buttonComponent.button.onClick.AddListener(() => {
                CreateButtonsForTopic(queryTopic);
            });

            // Actually add the button to the scene
            button.transform.SetParent(this.gameObject.transform, false);
        }
    }

    // Function to create the buttons for each topic
    public override void CreateButtonsForTopic(DialogQueryTopic topic)
    {
        ClearButtons();

        // Create a back button and get refernce to it 
        var backButtonComponent = CreateBackButton(CreateRootButtons);

        // Create a button for each conversation in the topic
        foreach (var convo in topic.conversations)
        {
            // Make button prefab
            GameObject convoButton = Instantiate(buttonPrefab) as GameObject;

            // Get button components
            var convoButtonComponent = convoButton.GetComponent<UIDialogButton>();

            // Set text & onClick for the main button components
            convoButtonComponent.text.text = convo.identifier;
            convoButtonComponent.button.onClick.AddListener(() => {
                CreateButtonsForDialogTree(convo, () => { CreateButtonsForTopic(topic); });
            });

            convoButton.transform.SetParent(this.gameObject.transform, false);
        }
    }

    // Creates buttons for the dialog tree
    public void CreateButtonsForDialogTree(DialogTreeWithId tree, UnityEngine.Events.UnityAction onBackButton)
    {
        ClearButtons();
        // Create a back button and get refernce to it 
        var backButtonComponent = CreateBackButton(onBackButton);

        foreach (DialogNodeWithID node in tree.dialogNodes)
        {
            // Make button prefab
            GameObject nodeButtonObject = Instantiate(buttonPrefab) as GameObject;

            // Get button components
            var nodeButtonComponent = nodeButtonObject.GetComponent<UIDialogButton>();

            // Set text & onClick for the main button components
            nodeButtonComponent.text.text = node.identifier;
            nodeButtonComponent.button.onClick.AddListener(() => {
                runner.SetCurrentNode(node);
            });


            nodeButtonObject.transform.SetParent(this.gameObject.transform, false);
        }
    }

    UIDialogButton CreateBackButton(UnityEngine.Events.UnityAction action)
    {
        // Instantiate button
        GameObject backButton = Instantiate(buttonPrefab) as GameObject;

        // Get the button component
        var backButtonComponent = backButton.GetComponent<UIDialogButton>();

        // Set name and listener
        backButtonComponent.text.text = "<- Back";
        backButtonComponent.button.onClick.AddListener(action);
        backButtonComponent.transform.SetParent(this.gameObject.transform, false);
        return backButtonComponent;
    }

    // Clears the current buttons
    void ClearButtons()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}