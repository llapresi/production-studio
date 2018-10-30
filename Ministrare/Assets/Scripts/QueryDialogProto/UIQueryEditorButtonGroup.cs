using System;
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
        // Clear all the current buttons if they exist
        ClearButtons();
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
            buttonComponent.button.onClick.AddListener(() => CreateButtonsForTopic(queryTopic));
            deleteComponent.onClick.AddListener(() => {
                rootQuery.topics.Remove(queryTopic);
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
        // Create a back button and get refernce to it 
        var backButtonComponent = CreateBackButton();

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
                runner.SetCurrentNode(convo.dialogTree.dialogNodes[0]);
                if (runner.GetType() == typeof(QueryDialogEditor))
                {
                    QueryDialogEditor runnerAsEditor = (QueryDialogEditor)runner;
                    runnerAsEditor.lastSelectedRenamable = convo;
                    runnerAsEditor.onSelect.Invoke();
                }
            });

            // Set onClick for the remove
            convoDeleteButton.onClick.AddListener(() =>
            {
                topic.conversations.Remove(convo);
                CreateButtonsForTopic(topic);
            });

            convoButton.transform.SetParent(this.gameObject.transform, false);
        }

        // Only run if DialogRunner is the editor
        if (runner.GetType() == typeof(QueryDialogEditor))
        {
            QueryDialogEditor runnerAsEditor = (QueryDialogEditor)runner;
            runnerAsEditor.SetCurrentDialogTopic(topic);
            backButtonComponent.button.onClick.AddListener(() => { runnerAsEditor.SetCurrentDialogTopic(); });
        }
    }

    UIDialogButton CreateBackButton()
    {
        // Instantiate button
        GameObject backButton = Instantiate(regularButtonPrefab) as GameObject;

        // Get the button component
        var backButtonComponent = backButton.GetComponent<UIDialogButton>();

        // Set name and listener
        backButtonComponent.text.text = "<- Back";
        backButtonComponent.button.onClick.AddListener(CreateRootButtons);
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

    // Update is called once per frame
    void Update()
    {

    }
}
