﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        // Change Dialog text to notifiy that the objective has been added to the chosen list
        GameObject GODialogText = GameObject.Find("DialogText");
        TextMeshProUGUI textMesh = GODialogText.GetComponent<TextMeshProUGUI>();
        textMesh.SetText("Military Leader: We will focus on that objective, my Leige.");
        Destroy(this.gameObject);
    }
}