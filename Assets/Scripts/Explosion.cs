using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Explosion : MonoBehaviour {
    GameObject TilemapGameObject;
    Tilemap tilemap;

 
    private void OnCollisionStay2D(Collision2D collision)
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
            Debug.Log("lolstay");
            Destroy(collision.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
        }

        //if (collision.gameObject is Enemy)
        //{

        //}
    }

    private void Start()
    {
        
        TilemapGameObject = GameObject.Find("Tilemap");
       
        tilemap = TilemapGameObject.GetComponent<Tilemap>();
        
        Destroy(gameObject, 0.5f);
    }

    
}
