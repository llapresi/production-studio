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
        runner = setRunner;
        rootQuery = setRunner.currentQuery;
        CreateRootButtons();
    }

    public override void CreateRootButtons()
    {
        ClearButtons();
        foreach (var queryTopic in rootQuery.topics)
        {
            GameObject button = Instantiate(editorButtonPrefab) as GameObject;
            var buttonParent = button.GetComponent<UIDialogButtonWithRemove>();
            var buttonComponent = buttonParent.dialogButton;
            buttonComponent.text.text = queryTopic.identifier;
            buttonComponent.button.onClick.AddListener(() => CreateButtonsForTopic(queryTopic));
            var deleteComponent = buttonParent.removeButton;
            deleteComponent.onClick.AddListener(() => {
                rootQuery.topics.Remove(queryTopic);
                CreateRootButtons();
            });
            button.transform.SetParent(this.gameObject.transform, false);
        }
    }

    // Function to create the buttons for each topic
    public override void CreateButtonsForTopic(DialogQueryTopic topic)
    {
        ClearButtons();
        // Create a back button
        GameObject backButton = Instantiate(regularButtonPrefab) as GameObject;
        var backButtonComponent = backButton.GetComponent<UIDialogButton>();
        backButtonComponent.text.text = "<- Back";
        backButtonComponent.button.onClick.AddListener(CreateRootButtons);
        backButtonComponent.transform.SetParent(this.gameObject.transform, false);

        // Create a button for each conversation in the topic
        foreach (var convo in topic.conversations)
        {
            GameObject convoButton = Instantiate(regularButtonPrefab) as GameObject;
            var convoButtonComponent = convoButton.GetComponent<UIDialogButton>();
            convoButtonComponent.text.text = convo.identifier;
            convoButtonComponent.button.onClick.AddListener(() => runner.SetCurrentNode(convo.dialogTree.dialogNodes[0]));
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

    // Clears the current buttons
    // BAD AND HACKY because we're instantiating and destroying buttons for every options
    // What we SHOULD be doing is creating all buttons at start and setting them active and inactive
    // but we'll get around to that
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
