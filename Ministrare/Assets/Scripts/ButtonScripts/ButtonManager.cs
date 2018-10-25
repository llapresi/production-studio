using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public enum buttonState {basic,select,done};

    private string[] opOne;
    private string[] opTwo;
    private string[] opThree;
    private string[] opFour;

    private string[][] ops;

    public GameObject buttonPrefab;

    public GameObject[] buttonList;

    string[] chosen;

    string firstEntry;
    string secondEntry;

    private Vector3 pos = new Vector3(200,400,0);


    private int arrayPlace;

    public buttonState state;

	// Use this for initialization
	void Start () {
        state = buttonState.basic;
        opOne = new string[] { "test1", "test2", "test3", "test4", "test5", "test6", "test7", "test8", "test9", "test10", "test11", "test12", "test13", "test14", "test15"};
        opTwo = new string[] { "test1", "test2", "test3"};
        opThree = new string[] { "test1", "test2", "test3", "test4", "test5", "test6", "test7", "test8", "test9", "test10", "test11", "test12"};
        opFour = new string[] { "test1", "test2", "test3", "test4", "test5", "test6", "test7" };
        initialized = false;
        ops = new string[][] { opOne, opTwo, opThree, opFour };
    }

    public bool initialized;
    bool cleared;
    bool selected;
	
	// Update is called once per frame
	void Update () {


        switch (state)
        {
            case buttonState.basic:
                Init();
                break;

            case buttonState.select:
                Selection();
                break;

            case buttonState.done:
                Clear();
                break;
        }


	}

    /// <summary>
    /// Places initial buttons and sets their attributes.  Only runs if not already initialized
    /// </summary>
    void Init()
    {
        if (initialized == false)
        {
            arrayPlace = 0;
            buttonList = new GameObject[4];
            for(int x = 0; x < 4; x++)
            {
                GameObject ob = CreateButton("test", ops[x]);
                buttonList[x] = ob;
                if (x % 2 == 0)
                {
                    pos.x += 200;
                }
                else
                {
                    pos.y -= 100;
                    pos.x = 200;
                }
            }
            initialized = true;
        }
    }


    /// <summary>
    /// Places slection buttons.  Only if not already placed
    /// </summary>
    void Selection()
    {
        if(selected == false)
        {
            pos.x = 200;
            pos.y = 500;
            selected = true;
            buttonList = new GameObject[chosen.Length];
            arrayPlace = 0;
            foreach (string entry in chosen)
            {
                createSelectionButton(entry);
              
            }
        }
    }

    /// <summary>
    /// Clears all buttons from screen.  only runs if not already cleared
    /// </summary>
    void Clear()
    {
        foreach (GameObject button in buttonList)
        {
            Destroy(button);

        }
    }

    /// <summary>
    /// creates a button with the given string as its text.  Used for initial buttons
    /// </summary>
    /// <param name="name"></param>
    GameObject CreateButton(string name, string[] op)
    {
        GameObject initButton = Instantiate(buttonPrefab);

        initButton.transform.SetParent(gameObject.transform);

        var button = initButton.GetComponent<UnityEngine.UI.Button>();

        button.onClick.AddListener(() => HandleClickBasic(op));

        initButton.GetComponentInChildren<Text>().text = name;

        initButton.transform.position = pos;

        buttonList[arrayPlace] = initButton;
        arrayPlace++;

        return initButton;
    }


    /// <summary>
    /// Creates a button with the given string as its text.  used for secondary buttons
    /// </summary>
    /// <param name="name"></param>
    GameObject createSelectionButton(string name)
    {
        GameObject selectButton = Instantiate(buttonPrefab);

        selectButton.transform.SetParent(gameObject.transform);

        var button = selectButton.GetComponent<UnityEngine.UI.Button>();

        button.onClick.AddListener(HandleClickSelect);

        selectButton.GetComponentInChildren<Text>().text = name;

        selectButton.transform.position = pos;

        configureSelectPosition();

        buttonList[arrayPlace] = selectButton;
        arrayPlace++;

        return selectButton;
    }

    /// <summary>
    /// Assigns click behavior for initial buttons
    /// </summary>
    void HandleClickBasic(string[] op)
    {
        Debug.Log("click");
        state = buttonState.select;
        chosen = op;
        foreach (GameObject button in buttonList)
        {
            Destroy(button);

        }
    }


    /// <summary>
    /// Assings click behavior for secondary buttons
    /// </summary>
    void HandleClickSelect()
    {

    }

    void configureSelectPosition()
    {
        int offset = 0;
        int posIncrease = 0;
        if(chosen.Length - arrayPlace > 5)
        {
            if((arrayPlace + 1) % 5 == 0)
            {
                pos.y -= 100;
                pos.x = 200;
            }
            else
            {
                pos.x += 200;
            }
        }
        else
        {
            if ((arrayPlace + 1) % 5 == 0)
            {
                pos.y -= 100;
                pos.x = 200;
            }
            if (offset != 0)
            {
                offset = 200 / (chosen.Length - arrayPlace);
                pos.x = 200 + offset;
            }
            pos.x += 200 + offset;
        }
    }
}
