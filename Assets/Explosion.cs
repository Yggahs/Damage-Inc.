using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);
    //}



    private void Start()
    {
        
        Destroy(gameObject, 1.5f);
    }

    
}
