using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Enemy {
    //public int damage = 1;
    private void Awake()
    {
        Destroy(gameObject,5f);
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.down*Time.deltaTime);
	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.name != "Head")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Tilemap")
        {
            Destroy(gameObject);
        }

        if (collision.name == "player")
        {
            Debug.Log("colpito");
            DealDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
