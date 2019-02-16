using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{
    public int health = 20;
    public int damage = 1;
    public CharacterController2D controller;
    public GameObject life1, life2, life3, life4, life5;
    public float runSpeed = 40f;
    float horizontalMove = 0f, timer;
    bool jump = false, crouch = false, airborne = false, facing = true, climbing = false;
    public bool invincible = false;
    public GameObject bullet;
    int i = 0, firespeed = 10;
    public GameObject BulletExit;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (GetComponent<Rigidbody2D>().velocity.y != 0 && climbing == false)
        {

            airborne = true;
            if (climbing == true) airborne = false;

        }
        else airborne = false;

        //Jump Command Logic
        if (Input.GetButtonDown("Jump"))
        { 
            if (airborne == false)
            {
                if (climbing)
                {
                    if (controller.m_FacingRight)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f, 0));
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(250f, 0));
                    }
                }
                jump = true;
            }
        }

        //Crounch Command Logic
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        DirectionalShooting();

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //Shooting Logic
    void DirectionalShooting()
    {
        Vector2 position = transform.position;

        //Shoot Right Up
        if (Input.GetKey(KeyCode.RightArrow))
        {
            i++;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (i == firespeed)
                {
                    GameObject go = Instantiate(bullet, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    i = 0;
                }
            }
            else if (i == firespeed)
            {
                GameObject go = Instantiate(bullet, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
                i = 0;
            }


        }
        //Shoot Left Up
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            i++;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (i == firespeed)
                {
                    GameObject go = Instantiate(bullet, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = -0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    i = 0;
                }
            }
            else if (i == firespeed)
            {
                position.x -= .5f;
                GameObject go = Instantiate(bullet, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = -0.1f;
                i = 0;
            }
        }
        //Shoot  Up
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            i++;
            if (i == firespeed)
            {
                position.y += .2f;
                GameObject go = (GameObject)Instantiate(bullet, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
                i = 0;
            }
        }
        //Shoot  Down
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            i++;
            if (i == firespeed)
            {
                position.y -= .5f;
                GameObject go = (GameObject)Instantiate(bullet, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = -0.1f;
                i = 0;
            }
        }

        //Dash logic

        if (timer > 0.5)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (facing == false)
                {

                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-30, 0), ForceMode2D.Impulse);

                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 0), ForceMode2D.Impulse);

                }

                timer = 0;
            }

        }

        if (Input.GetKey(KeyCode.A)) facing = false;
        if (Input.GetKey(KeyCode.D)) facing = true;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //WallClimbing and Sliding logic
        if (col.tag == "Terrain")
        {
            
            climbing = true;
            GetComponent<Rigidbody2D>().drag = 20;
            GetComponent<CharacterController2D>().m_JumpForce = 650;

            //print("Collision with: " + col.name);
        } 

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {

            if (invincible == false)
            {
                collision.transform.GetComponent<Enemy>().DealDamage();
                StartCoroutine(Invincible());
                print(health);
                if (health >= 16)
                {
                    life5.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else if (health >= 12)
                {
                    life4.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else if (health >= 8)
                {
                    life3.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else if (health >= 4)
                {
                    life2.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else
                {
                    life1.GetComponent<Image>().fillAmount -= 0.25f;
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //WallClimbing and Sliding logic
        if (col.tag == "Terrain")
        {
            climbing = false;
            GetComponent<Rigidbody2D>().drag = 0;
            GetComponent<CharacterController2D>().m_JumpForce = 400;
            //print("Collision with: " + col.name);
        }
    }

    private IEnumerator Invincible()
    {
        print("kek");
        invincible = true;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        invincible = false;



    }
}


