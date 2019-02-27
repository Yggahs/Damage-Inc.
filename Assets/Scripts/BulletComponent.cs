using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour {

    public float xspeed = 0f;
    public float yspeed = 0f;
    public int bulletType;
    float timer;

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 position = transform.position;
        position.x += xspeed;
        position.y += yspeed;
        transform.position = position;
        timer += Time.deltaTime;


        //Logic for Boomerang shot
        if (bulletType == 3)
        {
            if (timer > 0.5 && timer < 0.55)
            {
                GetComponent<BulletComponent>().yspeed = GetComponent<BulletComponent>().yspeed * -1;
                GetComponent<BulletComponent>().xspeed = GetComponent<BulletComponent>().xspeed * -1;
            }
        }
    }
}
