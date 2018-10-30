using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQueryEditorRenamePanel : MonoBehaviour {

    public QueryDialogEditor editorParent;
    public TMPro.TMP_InputField textInput;
    public CanvasGroup renamePanelCanvasGroup;

    public void OnValueChanged()
    {
        editorParent.RenameDialogTopic(textInput.text);
    }

    public void RefreshText()
    {
        if (editorParent.lastSelectedRenamable != null) {
            renamePanelCanvasGroup.interactable = true;
            renamePanelCanvasGroup.alpha = 1;
            textInput.text = editorParent.lastSelectedRenamable.GetName();
        } else
        {
            renamePanelCanvasGroup.interactable = false;
            renamePanelCanvasGroup.alpha = 0;
        }
    }
}
