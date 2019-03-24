using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBehavior : Enemy
{
    float _speed = 2f;
    float resetTime;
    public GameObject bullets;
    private void Start()
    {
        resetTime = 3f;
    }
    private void Update()
    {

        MouthLaser();   
    }

    void MouthLaser()
    {
        resetTime -= Time.deltaTime;
        if (resetTime <= 0)
        {
            GameObject bullet1 = Instantiate(bullets, transform.position, Quaternion.identity);
            
            bullet1.transform.eulerAngles = new Vector3(0, 0, 30);
            GameObject bullet2 = Instantiate(bullets, transform.position, Quaternion.identity);
            //bullet2.transform.Translate(Vector2.down);           
            GameObject bullet3 = Instantiate(bullets, transform.position, Quaternion.identity);
            
            bullet3.transform.eulerAngles = new Vector3(0, 0, -30);
            resetTime = 3f;
        }
    }

}
