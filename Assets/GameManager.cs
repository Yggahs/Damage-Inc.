using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject BombsUI, CollectUI;
    public TMP_Text Title, Description, InputButton;

    // Use this for initialization
    void Start ()
    {
        Title = GameObject.Find("Title").GetComponent<TMP_Text>();
        Description = GameObject.Find("Description").GetComponent<TMP_Text>();
        InputButton = GameObject.Find("InputButton").GetComponent<TMP_Text>();
        CollectUI = GameObject.Find("CollectUI");
        BombsUI = GameObject.Find("BombInfos");

        CollectUI.SetActive(false);
        BombsUI.SetActive(false);
        
    }

}
