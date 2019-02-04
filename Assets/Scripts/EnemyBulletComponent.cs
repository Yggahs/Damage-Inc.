using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletComponent : MonoBehaviour
{
    Rigidbody2D rb;
    float movespeed = 7f;
    GameObject target;
    Vector2 movedirection;
    GameObject PlayerRef;
    GameObject EnemyRef;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("player");
        movedirection = (target.transform.position - transform.position).normalized * movespeed;
        rb.velocity = new Vector2(movedirection.x, movedirection.y);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {

            PlayerRef.GetComponent<CharacterController2D>().health -= transform.parent.GetComponent<Shooter>().damage;
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        PlayerRef = GameObject.Find("player");
    }
}
