using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIQueryEditorSeralizedActionRow : MonoBehaviour {

    [SerializeField]
    TMP_InputField actionType;
    [SerializeField]
    TMP_InputField actionParams;
    public UnityEngine.UI.Button removeButton;
    DialogNodeSerializedAction nodeSerializedAction;

    public void SetActionFields(DialogNodeSerializedAction p_nodeSerializedAction)
    {
        nodeSerializedAction = p_nodeSerializedAction;
        actionType.text = nodeSerializedAction.actionType;
        actionParams.text = nodeSerializedAction.actionParams;
    }

    public void ChangeActionParams()
    {
        nodeSerializedAction.actionType = actionType.text;
        nodeSerializedAction.actionParams = actionParams.text;
    }
}
