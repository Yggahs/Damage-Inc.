using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : Enemy {

    public AudioClip DeathClip;
    public GameObject shockwaveL;
    public GameObject shockwaveR;
    bool movingDown;
    

    private void Start()
    {
        PlayerRef = transform.parent.parent.GetComponent<Enemy>().PlayerRef;
        movingDown = true;
    }

    private void Update()
    {       
        Boss_Arm(movingDown);
        Death(DeathClip);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.transform.name == "Tilemap")
        {
            if (movingDown == true)
            {
                Instantiate(shockwaveL, new Vector3(collision.contacts[0].point.x - 1f, collision.contacts[0].point.y - 0.25f,-1f), Quaternion.identity);
                Instantiate(shockwaveR, new Vector3(collision.contacts[0].point.x + 3f, collision.contacts[0].point.y - 0.25f, -1f), Quaternion.identity);   
            }
            else
            {
                Instantiate(shockwaveL, new Vector3(collision.contacts[0].point.x - 1f, collision.contacts[0].point.y + 1.5f, -1f), Quaternion.identity);
                Instantiate(shockwaveR, new Vector3(collision.contacts[0].point.x + 3f, collision.contacts[0].point.y + 1.5f, -1f), Quaternion.identity);
            }
            movingDown = !movingDown;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "player")
        {
            DealDamage(damage*3);
        }
    }
}
