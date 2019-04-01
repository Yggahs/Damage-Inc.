using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehaviourL : Enemy {

    private void Awake()
    {
        Destroy(gameObject, 4f);
    }
    private void Update()
    {       
        transform.Translate(Vector2.left * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
