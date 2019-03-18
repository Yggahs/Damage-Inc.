using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour {
    public GameObject Bomb;
    public int bombs = 5, maxBombs = 10;
    public bool bombUnlocked = false;

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
            }
        }
    }
}

