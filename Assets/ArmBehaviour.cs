using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : Enemy {
    public GameObject shockwaveL;
    public GameObject shockwaveR;
    bool touched_ground;
    private void Update()
    {
        Boss_Arm(touched_ground);
        Death();
        Debug.Log(transform.eulerAngles);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Tilemap")
        {
            touched_ground = true;
            Instantiate(shockwaveL, new Vector3(transform.position.x - 0.6f, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);          
            Instantiate(shockwaveR, new Vector3(transform.position.x + 0.6f, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);                                     
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.name == "Tilemap")
            touched_ground = false;
    }

}
