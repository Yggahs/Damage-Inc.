using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTilesScript : MonoBehaviour {

    public bool DoesKill;
    GameObject PlayerRef;
    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("GameController");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == PlayerRef.gameObject.name)
        {
            PlayerRef.GetComponent<CharacterController2D>().health = 0;
        }
        else
        {
            collision.gameObject.SetActive(false);
        }
        
    }

}
