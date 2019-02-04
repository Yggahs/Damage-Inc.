using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;
    public int damage;
    private bool movingRight;
    public Transform groundDetection;
    public Vector2 horizontalMove;
    public GameObject PlayerRef;
    public GameObject BulletRef;


    public void Patrol()
    {
        horizontalMove = Vector2.right * speed * Time.deltaTime;
        transform.Translate(horizontalMove);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void DealDamage()
	{
            Debug.Log("I am dealing " + damage + " damage");
            PlayerRef.GetComponent<control>().health -= damage;
            PlayerRef.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f, 200f));
        
    }

    private void Awake()
    {
        PlayerRef = GameObject.Find("player");
    }

    void TakeDamage(int DamageTaken)
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<control>().invincible == false)
        {
            health -= DamageTaken;
            Debug.Log("My health is now " + health);
        }
        else Debug.Log("I AM BULLETPROOF");

    }
}
