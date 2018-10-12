using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NextNodeLink contains the indicie of the next dialog node (according to the list it's stored in)
// and a 'displayText' field that dictates what the button name for this option should be on the dialog screen
[System.Serializable]
public class DialogNodeLink
{
    public int id;
    public string displayText;

    public DialogNodeLink(int p_id, string p_displayText)
    {
        id = p_id;
        displayText = p_displayText;
    }
}