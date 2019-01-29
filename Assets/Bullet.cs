using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    GameObject PlayerRef;
    private void Awake()
    {
        PlayerRef = GameObject.Find("player");
        damage = PlayerRef.GetComponent<control>().damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "player")
        {
            collision.SendMessage("TakeDamage", damage,SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
