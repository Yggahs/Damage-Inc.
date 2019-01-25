using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public GameObject bullet;
    int i = 0, firespeed = 10;
    // Update is called once per frame
    void Update()
    {

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
        //else if ((Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))|| (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))) // right up

        else if ((Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))) // right down
        {
            if (Input.GetButtonDown("Fire1"))
            {
                position.x += .5f;
                position.y -= .5f;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
            }
        }
        else if ((Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))) // left up
        {
            if (Input.GetButtonDown("Fire1"))
            {
                position.x -= .5f;
                position.y += .5f;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
            }

        }
        else if ((Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))) // left down
        {
            if (Input.GetButtonDown("Fire1"))
            {
                position.x -= .5f;
                position.y -= .5f;
                GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
            }
        }

    }
}
