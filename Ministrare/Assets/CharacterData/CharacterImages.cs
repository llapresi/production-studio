using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Holds background image and expressions for a given character
// NOTE: This is NOT a singleton var despite using scriptable objects
[CreateAssetMenu(fileName = "New CharacterImages Object", menuName = "Ministrare/CharacterImages/Character Images Object", order = 1)]
public class CharacterImages : ScriptableObject {

    [System.Serializable]
    public class CharacterImageWithID
    {
        public Sprite image;
        public string id;
    }

    public string id;
    public CharacterImageWithID[] images;

    public Sprite GetSpriteForID(string id)
    {
        foreach(CharacterImageWithID img in images)
        {
            if(img.id == id)
            {
                return img.image;
            }
        }
        return null;
    }
}
