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
        Debug.Log(collision.transform.name);
        foreach(ContactPoint2D hit in collision.contacts)
        {
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
        }
    }

    private void Start()
    {
        TilemapGameObject = GameObject.Find("Tilemap");
        tilemap = TilemapGameObject.GetComponent<Tilemap>();
        Destroy(gameObject, 0.5f);
    }

    
}
