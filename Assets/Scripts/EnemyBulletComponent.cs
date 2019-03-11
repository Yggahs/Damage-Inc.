using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletComponent : MonoBehaviour
{
    Rigidbody2D rb;
    float movespeed = 7f;
    GameObject target;
    Vector2 targetDirection;
    GameObject EnemyRef;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        target = transform.parent.GetComponent<Enemy>().Target;
        targetDirection = (target.transform.position - transform.position).normalized * movespeed;
        rb.velocity = new Vector2(targetDirection.x, targetDirection.y);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            transform.parent.GetComponent<Shooter>().DealDamage(transform.parent.GetComponent<Shooter>().damage);
            Destroy(gameObject);
        }
    }
}
