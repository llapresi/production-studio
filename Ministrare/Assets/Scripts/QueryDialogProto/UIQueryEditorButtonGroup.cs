﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object that creates a bunch of Unity UI Buttons as it's childern
// Ideally you should be able to point a query dialog runner at it and it'll make the all
// the relevant buttons for it
public class UIQueryEditorButtonGroup : BaseButtonGroup
{
    // Button prefab object
    public GameObject regularButtonPrefab;
    public GameObject editorButtonPrefab;

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
        ((QueryDialogEditor)runner).CurrentPath = "root";
        // Clear all the current buttons if they exist
        ClearButtons();

        // Set add button behaviour
        SetAddButtonBehaviour(rootQuery, null, CreateRootButtons);

        // Create a button for each topic
        foreach (var queryTopic in rootQuery.topics)
        {
            // Create button prefab
            GameObject button = Instantiate(editorButtonPrefab) as GameObject;

            // Get the Button prefab with the remove button and their associated buttons
            var buttonParent = button.GetComponent<UIDialogButtonWithRemove>();
            var buttonComponent = buttonParent.dialogButton;
            var deleteComponent = buttonParent.removeButton;

            // Set button text and onClick's
            buttonComponent.text.text = queryTopic.identifier;
            buttonComponent.button.onClick.AddListener(() => {
                CreateButtonsForTopic(queryTopic);
            });

            deleteComponent.onClick.AddListener(() => {
                // Remove the topic from the list
                rootQuery.topics.Remove(queryTopic);
                // Calling this function again to refresh the view
                CreateRootButtons();
            });

            // Actually add the button to the scene
            button.transform.SetParent(this.gameObject.transform, false);
        }
    }

    // Function to create the buttons for each topic
    public override void CreateButtonsForTopic(DialogQueryTopic topic)
    {
        ClearButtons();

        // Set the add button behaviour
        SetAddButtonBehaviour(topic, topic, () => { CreateButtonsForTopic(topic); });

        ((QueryDialogEditor)runner).CurrentPath = String.Format("root/{0}", topic.identifier);

        // Create a back button and get refernce to it 
        var backButtonComponent = CreateBackButton(CreateRootButtons);

        // Create a button for each conversation in the topic
        foreach (var convo in topic.conversations)
        {
            // Make button prefab
            GameObject convoButton = Instantiate(editorButtonPrefab) as GameObject;

            // Get button components
            var convoButtonParent = convoButton.GetComponent<UIDialogButtonWithRemove>();
            var convoButtonComponent = convoButtonParent.dialogButton;
            var convoDeleteButton = convoButtonParent.removeButton;

            // Set text & onClick for the main button components
            convoButtonComponent.text.text = convo.identifier;
            convoButtonComponent.button.onClick.AddListener(() => {
                var path = String.Format("root/{0}/{1}", topic.identifier, convo.identifier);
                if (runner.GetType() == typeof(QueryDialogEditor))
                {
                    QueryDialogEditor runnerAsEditor = (QueryDialogEditor)runner;
                    runnerAsEditor.lastSelectedRenamable = convo;
                    runnerAsEditor.CurrentPath = path;
                    runnerAsEditor.onSelect.Invoke();
                }
                CreateButtonsForDialogTree(convo, () => { CreateButtonsForTopic(topic); }, path);
            });

            // Set onClick for the remove
            convoDeleteButton.onClick.AddListener(() =>
            {
                topic.conversations.Remove(convo);
                CreateButtonsForTopic(topic);
            });

            convoButton.transform.SetParent(this.gameObject.transform, false);
        }
    }

    // Creates buttons for the dialog tree
    public void CreateButtonsForDialogTree(DialogTreeWithId tree, UnityEngine.Events.UnityAction onBackButton, string basePathString)
    {
        ClearButtons();
        // Create a back button and get refernce to it 
        var backButtonComponent = CreateBackButton(onBackButton);

        // Set add button
        SetAddButtonBehaviour(tree, tree, () => {
            CreateButtonsForDialogTree(tree, onBackButton, basePathString);
        });

        foreach (DialogNodeWithID node in tree.dialogNodes)
        {
            // Make button prefab
            GameObject nodeButtonObject = Instantiate(editorButtonPrefab) as GameObject;

            // Get button components
            var nodeButtonParent = nodeButtonObject.GetComponent<UIDialogButtonWithRemove>();
            var nodeButtonComponent = nodeButtonParent.dialogButton;
            var nodeDeleteButton = nodeButtonParent.removeButton;

            // Set text & onClick for the main button components
            nodeButtonComponent.text.text = node.identifier;
            nodeButtonComponent.button.onClick.AddListener(() => {
                runner.SetCurrentNode(node);
                QueryDialogEditor runnerAsEditor = (QueryDialogEditor)runner;
                runnerAsEditor.lastSelectedRenamable = node;
                runnerAsEditor.onSelect.Invoke();
                runnerAsEditor.CurrentPath = String.Format("{0}/{1}", basePathString, node.identifier);
            });

            // Set onClick for the remove
            nodeDeleteButton.onClick.AddListener(() =>
            {
                tree.dialogNodes.Remove(node);
                CreateButtonsForDialogTree(tree, onBackButton, basePathString);
            });

            nodeButtonObject.transform.SetParent(this.gameObject.transform, false);
        }
    }

    UIDialogButton CreateBackButton(UnityEngine.Events.UnityAction action)
    {
        // Instantiate button
        GameObject backButton = Instantiate(regularButtonPrefab) as GameObject;

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

    void SetAddButtonBehaviour(IEditorAddable addable, IEditorRenamable renamable, RefreshButtonsDelegate action)
    {
        QueryDialogEditor runnerAsEditor = (QueryDialogEditor)runner;
        runnerAsEditor.lastSelectedAddable = addable;
        runnerAsEditor.lastSelectedRenamable = renamable;
        runnerAsEditor.refreshButtonMethod = action;
        runnerAsEditor.onSelect.Invoke();
    }
}