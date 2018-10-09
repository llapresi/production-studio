using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroupLeader : MonoBehaviour {

    public string Text;
    public string BackGroundNum;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseEnter()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.blue;
    }

    void OnMouseExit()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }

    void OnMouseDown()
    {
        Debug.Log("Button Clicked");
        //GameObject Manager = GameObject.Find("GameManager");
        //GameManager gameManager = Manager.GetComponent<GameManager>();
        //if (gameManager.BackGroundIn == false)
        //{
        //    GameObject gameObject = GameObject.Find("BackGround" + BackGroundNum);
        //    Transform transform = gameObject.GetComponent<Transform>();
        //    transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        //    gameManager.BackGroundIn = true;
        //}
        SceneManager.LoadSceneAsync("Scenes/LukeDialogTest", LoadSceneMode.Additive);
    }
}
