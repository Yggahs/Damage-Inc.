using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : Enemy
{
    private void Update()
    {
        //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Crawl();
        //Patrol();
        Death();        
    }
}
