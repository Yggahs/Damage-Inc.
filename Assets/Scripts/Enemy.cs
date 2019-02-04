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
    public GameObject EnemyBulletRef;
    public float fireRate;
    float nextFire;
    bool TargetAcquired = false;

    public void Patrol()
    {
        horizontalMove = Vector2.right * speed * Time.deltaTime;
        transform.Translate(horizontalMove);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
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

    public void Shoot()
    {

        if (TargetAcquired == true)
        {
            if (Time.time > nextFire)
            {
                Instantiate(EnemyBulletRef, transform.position, transform.rotation,transform);
                nextFire = Time.time + fireRate;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            TargetAcquired = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            TargetAcquired = false;
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
        Debug.Log("I am dealing "+ damage +" damage");
        PlayerRef.GetComponent<CharacterController2D>().health -= damage;
        PlayerRef.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f, 200f));
	}

    private void Awake()
    {
        PlayerRef = GameObject.Find("player");
        nextFire = Time.time;
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
