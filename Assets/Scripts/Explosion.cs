using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Explosion : MonoBehaviour {
    GameObject TilemapGameObject;
    GameObject PlayerRef;
    Enemy Enemy;
    Tilemap tilemap;
    int damage = 4;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        Vector3 hitPosition = Vector3.zero;
        //Debug.Log(collision.transform.name);
        if (collision.gameObject.tag == "Destructible")
        {
            //foreach (ContactPoint2D hit in collision.contacts)
            //{

            //    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            //    hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
            //    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

            //}
            //Debug.Log("lolstay");
            Destroy(collision.gameObject);
        }
        //else if (collision.gameObject == PlayerRef)
        //{
        //    PlayerRef.GetComponent<CharacterController2D>().health -= damage;
        //}
        //else if (collision.gameObject.tag == "Enemy")
        //{
        //    collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerRef)
        {
            PlayerRef.GetComponent<CharacterController2D>().health -= damage;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Vector3 hitPosition = Vector3.zero;
    //    if (collision.gameObject.tag == "Destructible")
    //    {
    //        Destroy(collision.gameObject);
    //    }

    //    //if (collision.gameObject is Enemy)
    //    //{

    //    //}
    //}

    private void Start()
    {
        
        TilemapGameObject = GameObject.Find("Tilemap");
        PlayerRef = GameObject.Find("player");

        tilemap = TilemapGameObject.GetComponent<Tilemap>();
        
        Destroy(gameObject, 0.5f);
    }

    
}
