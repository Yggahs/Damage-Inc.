using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Explosion : MonoBehaviour {
   
    GameObject PlayerRef;
    Enemy Enemy;
 
    int damage = 4;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destructible")
        { 
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == PlayerRef)
        {
            if (!PlayerRef.GetComponent<CharacterController2D>().invincible)
            {
                PlayerRef.GetComponent<CharacterController2D>().health -= damage;
            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }


    private void Start()
    {
        
        
        PlayerRef = GameObject.Find("player");

        
        
        Destroy(gameObject, 0.5f);
    }

    
}
