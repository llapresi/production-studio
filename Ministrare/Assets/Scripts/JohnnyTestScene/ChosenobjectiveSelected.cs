using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosenobjectiveSelected : MonoBehaviour {
    public string Name;
    public Military military;

    public void Start()
    {
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(setObjectives);
        this.gameObject.name = "CObjectiveButton";
    }

    // if selected, give the name to game manager
    public void setObjectives()
    {
        military.placeSelectedObjinUnchosenList(Name);
        Destroy(this.gameObject);
    }
}
