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

        if (Input.GetKeyDown(KeyCode.RightArrow) /*&& Input.GetButtonDown("Fire1")*/)
        {
            position.x += .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().xspeed = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) /*&& Input.GetButtonDown("Fire1")*/ )
        {
            position.x -= .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().xspeed = -0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) /*&& Input.GetButtonDown("Fire1")*/ )
        {
            position.y += .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().yspeed = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) /*&& Input.GetButtonDown("Fire1")*/ )
        {
            position.y -= .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().yspeed = -0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.UpArrow)) // right up
        {
            position.x += .5f;
            position.y += .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().xspeed = 0.1f;
            go.GetComponent<BulletComponent>().yspeed = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.DownArrow)) // right up
        {
            position.x += .5f;
            position.y -= .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().xspeed = 0.1f;
            go.GetComponent<BulletComponent>().yspeed = 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.UpArrow)) // right up
        {

            position.x -= .5f;
            position.y += .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().xspeed = 0.1f;
            go.GetComponent<BulletComponent>().yspeed = 0.1f;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.DownArrow)) // right up
        {
            position.x -= .5f;
            position.y -= .5f;
            GameObject go = (GameObject)Instantiate(bullet, position, Quaternion.identity);
            go.GetComponent<BulletComponent>().xspeed = 0.1f;
            go.GetComponent<BulletComponent>().yspeed = 0.1f;
        }

    }
}
