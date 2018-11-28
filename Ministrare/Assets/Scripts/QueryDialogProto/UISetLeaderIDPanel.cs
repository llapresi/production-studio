using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetLeaderIDPanel : MonoBehaviour {

    QueryDialogEditor editorParent = null;
    public TMPro.TMP_InputField textInput;

    public void OnValueChanged()
    {
        if(editorParent != null)
        {
            editorParent.SetLeaderID(textInput.text);
        }
    }

    public void Setup(QueryDialogEditor p_editorParent)
    {
        editorParent = p_editorParent;
        textInput.text = editorParent.currentQuery.leaderID;
    }
}
