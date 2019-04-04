using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject BombsUI, CollectUI;
    public Text Title, Description, InputButton;

    // Use this for initialization
    void Start ()
    {
        Title = GameObject.Find("Title").GetComponent<Text>();
        Description = GameObject.Find("Description").GetComponent<Text>();
        InputButton = GameObject.Find("InputButton").GetComponent<Text>();
        CollectUI = GameObject.Find("CollectUI");
        BombsUI = GameObject.Find("BombInfos");

        CollectUI.SetActive(false);
        BombsUI.SetActive(false);
        
    }

}
