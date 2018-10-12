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

	// Use this for initialization
	public void CreateButtons (DialogQuery dialogQuery) {
        foreach (var queryTopic in dialogQuery.topics)
        {
            GameObject button = Instantiate(buttonPrefab) as GameObject;
            button.GetComponent<UIDialogButton>().text.text = queryTopic.identifier;
            button.transform.SetParent(gameObject.transform, false);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
