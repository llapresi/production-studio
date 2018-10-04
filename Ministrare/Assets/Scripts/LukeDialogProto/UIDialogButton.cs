using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We have to make this because just using a UnityEngine.UI.Button doesn't let you easily
// change the button text for whatever dumb reason
public class UIDialogButton : MonoBehaviour {

    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Text text;
}
