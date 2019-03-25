using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject BombsUI, CollectablesUI;
    public TMP_Text Title, Description, InputButton;
    // Use this for initialization
    void Start ()
    {
        Title = GameObject.Find("Title").GetComponent<TMP_Text>();
        Description = GameObject.Find("Description").GetComponent<TMP_Text>();
        InputButton = GameObject.Find("InputButton").GetComponent<TMP_Text>();
        CollectablesUI = GameObject.Find("CollectibleFeedback");
        BombsUI = GameObject.Find("BombInfos");

        BombsUI.SetActive(false);
        CollectablesUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
