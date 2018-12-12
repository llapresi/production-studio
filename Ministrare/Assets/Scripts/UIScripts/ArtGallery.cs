using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArtGallery : MonoBehaviour {

	// Use this for initialization
	void Start () {
        index = 0;
        backInd = 1;
        shiftBackground();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private List<Sprite> curList = new List<Sprite>();

    public List<GameObject> buttListOne = new List<GameObject>();
    public List<GameObject> buttListTwo = new List<GameObject>();
    public List<GameObject> buttListThree = new List<GameObject>();

    public List<Sprite> CharListOne = new List<Sprite>();
    public List<Sprite> CharListTwo = new List<Sprite>();
    public List<Sprite> CharListThree = new List<Sprite>();
    public List<Sprite> BackList = new List<Sprite>();
    public List<Sprite> EndList = new List<Sprite>();

    public int backInd;

    public Image display;
    public Image backdrop;

    private int index;

    public void nextImage()
    {
        if (index < curList.Count - 1)
        {
            index++;
            display.sprite = curList[index];
        }
    }

    public void lastImage()
    {
        if (index != 0)
        {
            index--;
            display.sprite = curList[index];
        }
    }

    public void ChangeList(List<Sprite> newList)
    {
        curList = newList;
        shiftBackground();
        display.enabled = true;
        foreach (GameObject button in buttListOne)
        {
            button.SetActive(false);
        }
        foreach (GameObject button in buttListTwo)
        {
            button.SetActive(false);
        }
        foreach (GameObject button in buttListThree)
        {
            button.SetActive(true);
        }
        display.sprite = curList[0];
        index = 0;
    }

    public void hideList()
    {
        shiftBackground();
        display.enabled = false;
        foreach (GameObject button in buttListOne)
        {
            button.SetActive(true);
        }
        foreach (GameObject button in buttListThree)
        {
            button.SetActive(false);
        }
        foreach (GameObject button in buttListTwo)
        {
            button.SetActive(false);
        }
    }

    public void HideSubMenu()
    {
        foreach (GameObject button in buttListTwo)
        {
            button.SetActive(false);
        }
        foreach (GameObject button in buttListOne)
        {
            button.SetActive(true);
        }
    }

    public void ShowSubMenu()
    {
        foreach (GameObject button in buttListTwo)
        {
            button.SetActive(true);
        }
        foreach (GameObject button in buttListOne)
        {
            button.SetActive(false);
        }
    }

    public void callListChange(int x)
    {
        switch (x)
        {
            case 1:
                ChangeList(CharListOne);
                break;
            case 2:
                ChangeList(CharListTwo);
                break;
            case 3:
                ChangeList(CharListThree);
                break;
            case 4:
                ChangeList(BackList);
                break;
            case 5:
                ChangeList(EndList);
                break;
        }

    }

    public void shiftBackground()
    {
        switch (backInd)
        {
            case 0:
                backdrop.color = new Color(0, 0, 0);
                backInd = 1;
                break;
            case 1:
                backdrop.color = new Color(1, 1, 1);
                backInd = 0;
                break;
        }
    }

}
