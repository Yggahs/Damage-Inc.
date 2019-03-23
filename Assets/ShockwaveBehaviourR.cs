using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehaviourR : Enemy
{

    private void Update()
    {
        Debug.Log("vivoR");
        transform.Translate(Vector2.right * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
