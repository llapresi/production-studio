using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplayPlayerStats : MonoBehaviour {

    public PlayerStatsObject playerStats;
    public TextMeshProUGUI uiDisplay;

    // Use this for initialization
    void Start () {
        UpdateUI();
    }

    public void UpdateUI()
    {
        uiDisplay.text = "Inteligence: " + playerStats.runtimeInteligence + "\nFear: " + playerStats.runtimeFear + "\nPersuasion: " + playerStats.runtimePersuasion;
    }
}
