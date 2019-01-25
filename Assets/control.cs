using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f, timer;
    bool jump = false;
    bool crouch = false;
    public GameObject bullet;
    int i = 0, firespeed = 10;
    bool facing = true;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        print(timer);
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

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

    void DirectionalShooting()
    {
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.RightArrow) /*&& Input.GetButtonDown("Fire1")*/)
        {
            i++;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (i == firespeed)
                {
                    position.x += .5f;
                    position.y += .5f;
                    GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    i = 0;
                }
            }
            else if(i== firespeed) 
                 {
                    GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    i = 0;
                 }


        }
        else if (Input.GetKey(KeyCode.LeftArrow) /*&& Input.GetButtonDown("Fire1")*/ )
        {
            i++;            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (i == firespeed)
                {
                    position.x += .5f;
                    position.y += .5f;
                    GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = -0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    i = 0;
                }
            }
            else if (i == firespeed)
                {
                    position.x -= .5f;
                    GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = -0.1f;
                    i = 0;
                }
        }
        else if (Input.GetKey(KeyCode.UpArrow) /*&& Input.GetButtonDown("Fire1")*/ )
        {
            i++;
            if (i == firespeed)
            {
                position.y += .5f;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
                i = 0;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) /*&& Input.GetButtonDown("Fire1")*/ )
        {
            i++;
            if (i == firespeed)
            {
                position.y -= .5f;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = -0.1f;
                i = 0;
            }
        }

        //Dash logic

        
        if (timer > 0.5)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                print(timer);
                //transform.Translate(Vector3.forward * Time.deltaTime);
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 0));
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
}
