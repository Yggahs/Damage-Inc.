using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;
    public int damage;
    private bool movingRight;
    public Transform groundDetection;
    public Transform ActualGroundDetection;
    public Vector2 horizontalMove;    
    public GameObject PlayerRef;
    public GameObject BulletRef;
    public GameObject EnemyBulletRef;
    public float fireRate;
    float nextFire;
    bool inGeometry = false;
    bool TargetAcquired = false;
    Vector3 targetPostion;

    public void Fly()
    {
        if (TargetAcquired)
        {
            speed = 2.0f;
            transform.position = Vector2.MoveTowards(transform.position, PlayerRef.transform.position, speed * Time.deltaTime);
        }
        else
        {
            speed = 0.5f;
            RandomMovementFly();

        }
    }

    void RandomMovementFly()
    {
        float resetTime = 0f;
        resetTime -= Time.deltaTime;
        if (resetTime <= 0)
    { 
        if (transform.position != targetPostion  || inGeometry)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
            }
            else
            {
                targetPostion = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            }
            resetTime = 3f;
    }
        
        //    target = new Vector2(Random.Range(-5f, 5), Random.Range(-5f, 5)).normalized;

        //}

        /*= Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);*/

    }

    //doesn't currently work   
    public void Crawl()
    {
        
        
        horizontalMove = Vector2.right * speed * Time.deltaTime;
        transform.Translate(horizontalMove);
        RaycastHit2D hit = Physics2D.Raycast(ActualGroundDetection.position,Vector2.down,0.25f);

        
        if(hit == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z+90f, transform.rotation.w),1);
        }
        else
        {
            transform.up = hit.normal;
        }


    }


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.otherCollider.name == "Tilemap")
        {
            inGeometry = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            inGeometry = false;
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
