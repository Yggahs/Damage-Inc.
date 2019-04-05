using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health, maxHealth;
    public float speed;
    public int damage;
    private bool movingRight;
    public Transform groundDetection;
    public Transform ActualGroundDetection;
    public Vector2 horizontalMove;    
    public GameObject PlayerRef;
    public GameObject BulletRef;
    public GameObject EnemyBulletRef;
    public GameObject Target;
    private AudioSource EnemyDeaths;
    public float fireRate;
    float nextFire;
    bool inGeometry = false;
    public bool TargetAcquired = false;
    public Vector3 targetPostion, facing;

    //public void Burrow()
    //{
    //    Vector3 heading = transform.position - PlayerRef.transform.position;
    //    float distance = heading.magnitude;

    //    if (distance < 2f)
    //    {
    //        GetComponent<Rigidbody2D>().AddForce(transform.up);           
    //    }

    //    //if (inGeometry)
    //    //{

    //    //}
    //}

        
    public void Boss_Arm(bool movingDown)
    {
        
        transform.Translate(Vector3.down * Time.deltaTime* 5f);      
        if (movingDown == true)
        {
            transform.eulerAngles = new Vector3(-180, 0,0);
            movingDown = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingDown = true;
        }
    }

    public void LoungeAtPlayer(float distance,Vector3 direction)
    {
        if (distance < 0.5f && distance > 0.4f)
            {
                GetComponent<Rigidbody2D>().AddForce(direction + (Vector3.up * 50f));
            }          
    }
    public void Sprint()
    {     
        Vector3 heading = transform.position - PlayerRef.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
        if (TargetAcquired)
        {
                transform.position = Vector2.MoveTowards(transform.position, PlayerRef.transform.position, (speed * 2) * Time.deltaTime);
                LoungeAtPlayer(distance,direction);
        }
        facing = direction;
    }

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
    }

    
    // turning rigidbody to kinematic in crawler script
    public void Crawl()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(ActualGroundDetection.position, -transform.up, 0.10f);
        RaycastHit2D hit2 = Physics2D.Raycast(groundDetection.position, -transform.up, 0.3f);
        RaycastHit2D hit3 = Physics2D.Raycast(groundDetection.position, transform.right, 0.2f);
        GetComponent<Rigidbody2D>().AddForce(-transform.up * 2f);
        
            if (!hit && !hit2)
            {
                transform.RotateAround(ActualGroundDetection.position, Vector3.forward, -1f);
            }
            else
            {
                horizontalMove = Vector2.right * speed * Time.deltaTime;
                transform.Translate(horizontalMove);
            }
            if (hit3)
            {
                transform.RotateAround(transform.position, Vector3.forward, 10f);
            }
        Debug.DrawLine(ActualGroundDetection.position, ActualGroundDetection.position + -transform.up*0.1f,Color.red);
        Debug.DrawLine(groundDetection.position, groundDetection.position + -transform.up * 0.22f, Color.blue);
        Debug.DrawLine(groundDetection.position, groundDetection.position + transform.right * 0.2f, Color.yellow);
    }


    public void Patrol()
    {        
        horizontalMove = Vector2.right * speed * Time.deltaTime;
        transform.Translate(horizontalMove);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        RaycastHit2D WallInfo = Physics2D.Raycast(groundDetection.position, groundDetection.right, 0.07f);
        if (groundInfo.collider == false || WallInfo)
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
                Instantiate(EnemyBulletRef, transform.position, Quaternion.identity, transform);
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.name == "player")
        {
            DealDamage(damage);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            inGeometry = false;
        }        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerRef)
        {
            TargetAcquired = true;
            Target = collision.gameObject;         
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerRef)
        {
            TargetAcquired = false;
            Target = null;
        }
    }

    public void Death(AudioClip DeathClip)
    {
        if (health <= 0)
        {
            //EnemyDeaths.clip = DeathClip;
            //EnemyDeaths.Play();
            gameObject.SetActive(false);
        }
        
    }

    public void Respawn()
    {
        health = maxHealth;
        gameObject.SetActive(true);
    }
    public void DealDamage(int damage)
	{
        if (!PlayerRef.GetComponent<CharacterController2D>().invincible)
        {
            Debug.Log("I am dealing " + damage + " damage");
            PlayerRef.GetComponent<CharacterController2D>().health -= damage;
            PlayerRef.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f, 200f));
        }
	}

    private void Awake()
    {
        nextFire = Time.time;
    }

    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("GameController");
        EnemyDeaths = GameObject.Find("EnemyDeaths").GetComponent<AudioSource>();

    }

    public void TakeDamage(int DamageTaken)
    {
            health -= DamageTaken;
            Debug.Log("My health is now " + health);
    }
}
