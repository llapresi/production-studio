using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UIEditorSeralizedActionsParent : MonoBehaviour {

    public GameObject seralizedActionRowPrefab;
    public GameObject addActionRowPrefab;

    public void CreateActionRowsForNode(DialogNode node)
    {
        ClearButtons();
        if(node.serializedActions != null)
        {
            foreach (DialogNodeSerializedAction action in node.serializedActions)
            {
                // Setup Row Fields
                GameObject newActionRow = Instantiate(seralizedActionRowPrefab);
                newActionRow.transform.SetParent(this.gameObject.transform, false);
                var actionRowComponent = newActionRow.GetComponent<UIQueryEditorSeralizedActionRow>();
                actionRowComponent.SetActionFields(action);

                // Setup Delete Button
                actionRowComponent.removeButton.onClick.AddListener(() =>
                {
                    var serialzedList = node.serializedActions.OfType<DialogNodeSerializedAction>().ToList();
                    serialzedList.Remove(action);
                    node.serializedActions = serialzedList.ToArray();
                    CreateActionRowsForNode(node);
                });
            }
        }
        CreateAddButton(node);
    }

    void ClearButtons()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    void CreateAddButton(DialogNode node)
    {
        GameObject addActionButton = Instantiate(addActionRowPrefab);
        addActionButton.transform.SetParent(this.gameObject.transform, false);
        var addButton = addActionButton.GetComponent<UnityEngine.UI.Button>();
        addButton.onClick.AddListener(() =>
        {
            List<DialogNodeSerializedAction> serialzedList;
            if (node.serializedActions != null)
            {
                serialzedList = node.serializedActions.OfType<DialogNodeSerializedAction>().ToList();
            }
            else
            {
                serialzedList = new List<DialogNodeSerializedAction>();
            }
            serialzedList.Add(new DialogNodeSerializedAction("modifyStats", "[Statname] [Number]"));
            node.serializedActions = serialzedList.ToArray();
            CreateActionRowsForNode(node);
        });
    }
}
