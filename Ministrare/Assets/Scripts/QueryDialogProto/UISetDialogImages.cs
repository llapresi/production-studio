using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetDialogImages : MonoBehaviour {

    public CharacterImages[] characterImageObjectsToCheck;

    [SerializeField]
    Image sceneBackground;

    [SerializeField]
    Image sceneCharacter;

    public void SetBackground(string identifier)
    {
        foreach(CharacterImages character in characterImageObjectsToCheck)
        {
            if(character.id == identifier)
            {
                // Set the background and also the neutral character sprite
                sceneBackground.sprite = character.GetSpriteForID("background");
                sceneCharacter.sprite = character.GetSpriteForID("neutral");
            }
        }
    }
}
