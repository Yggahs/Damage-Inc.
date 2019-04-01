using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehaviourR : Enemy
{
    private void Awake()
    {
        Destroy(gameObject, 4f);
    }
    private void Update()
    {
        
        transform.Translate(Vector2.right * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
