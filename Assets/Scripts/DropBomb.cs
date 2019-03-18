using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropBomb : MonoBehaviour {
    public GameObject Bomb;
    public int bombs = 5, maxBombs = 10;
    public bool bombUnlocked = false;
    public Text BombsText;



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            UseBomb();
        }
    }

    private void UseBomb()
    {
        if (bombUnlocked)
        {
            if (bombs > 0)
            {
                Instantiate(Bomb, gameObject.GetComponent<Transform>().position, Quaternion.identity);
                bombs--;
                BombsText.text = bombs.ToString() + "/" + maxBombs.ToString(); 
            }
        }
    }
}

