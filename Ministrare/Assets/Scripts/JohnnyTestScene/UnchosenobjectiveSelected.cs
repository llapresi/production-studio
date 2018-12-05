using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnchosenobjectiveSelected : MonoBehaviour {
    public string Name;
    public Military military;

    public void Start()
    {
        Button button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(setObjectives);
        this.gameObject.name = "UObjectiveButton";
    }

    // if selected, give the name to game manager
    public void setObjectives()
    {
        military.placeSelectedObjinChosenList(Name);
        Destroy(this.gameObject);
    }
}
