using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehaviourL : Enemy {

    private void Update()
    {
        Debug.Log("vivoL");
        transform.Translate(Vector2.left * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(gameObject);
    }
}
