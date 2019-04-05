using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject BombsUI, CollectUI, VictoryScreen;
    public Text Title, Description, InputButton;

    // Use this for initialization
    void Start ()
    {
        Title = GameObject.Find("Title").GetComponent<Text>();
        Description = GameObject.Find("Description").GetComponent<Text>();
        InputButton = GameObject.Find("InputButton").GetComponent<Text>();
        CollectUI = GameObject.Find("CollectUI");
        BombsUI = GameObject.Find("BombInfos");
        VictoryScreen = GameObject.Find("VictoryMenu");

        CollectUI.SetActive(false);
        BombsUI.SetActive(false);
        VictoryScreen.SetActive(false);

    }

}
