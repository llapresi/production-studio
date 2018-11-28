using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetDialogImages : MonoBehaviour {

    public CharacterImages[] characterImageObjectsToCheck;
    public Image background;

	public void SetBackground(string identifier)
    {
        foreach(CharacterImages character in characterImageObjectsToCheck)
        {
            if(character.id == identifier)
            {
                background.sprite = character.GetSpriteForID("background");
            }
        }
    }
}
