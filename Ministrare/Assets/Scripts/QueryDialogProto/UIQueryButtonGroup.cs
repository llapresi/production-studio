using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object that creates a bunch of Unity UI Buttons as it's childern
// Ideally you should be able to point a query dialog runner at it and it'll make the all
// the relevant buttons for it
public class UIQueryButtonGroup : MonoBehaviour
{
    // Button prefab object
    public GameObject buttonPrefab;

    // dialog query we're querying. This is set in QueryDialogRunner
    public DialogQuery rootQuery;

	// Use this for initialization
	public void CreateRootButtons () {
        ClearButtons();
        foreach (var queryTopic in rootQuery.topics)
        {
            GameObject button = Instantiate(buttonPrefab) as GameObject;
            var buttonComponent = button.GetComponent<UIDialogButton>();
            buttonComponent.text.text = queryTopic.identifier;
            buttonComponent.button.onClick.AddListener(() => CreateButtonsForTopic(queryTopic));
            button.transform.SetParent(this.gameObject.transform, false);
        }

    }

    // Function to create the buttons for each topic
    void CreateButtonsForTopic (DialogQueryTopic topic)
    {
        ClearButtons();
        // Create a back button
        GameObject backButton = Instantiate(buttonPrefab) as GameObject;
        var backButtonComponent = backButton.GetComponent<UIDialogButton>();
        backButtonComponent.text.text = "<- Back";
        backButtonComponent.button.onClick.AddListener(CreateRootButtons);
        backButtonComponent.transform.SetParent(this.gameObject.transform, false);

        // Create a button for each conversation in the topic
        foreach (var convo in topic.conversations)
        {
            GameObject convoButton = Instantiate(buttonPrefab) as GameObject;
            var convoButtonComponent = convoButton.GetComponent<UIDialogButton>();
            convoButtonComponent.text.text = convo.identifier;
            convoButtonComponent.button.onClick.AddListener(() => Debug.Log(convo.identifier + " button pressed"));
            convoButton.transform.SetParent(this.gameObject.transform, false);
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
	void Update () {
		
	}
}
