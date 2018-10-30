using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQueryEditorRenamePanel : MonoBehaviour {

    public QueryDialogEditor editorParent;
    public TMPro.TMP_InputField textInput;

    public void OnValueChanged()
    {
        editorParent.RenameDialogTopic(textInput.text);
    }

    public void RefreshText()
    {
        textInput.text = editorParent.lastSelectedRenamable.GetName();
    }
}
