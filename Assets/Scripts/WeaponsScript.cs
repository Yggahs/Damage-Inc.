using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class WeaponsScript : MonoBehaviour
{
    int i = 0, firespeed = 10;
    public GameObject bullet1, bullet2, bullet3;
    public GameObject BulletExit;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void Weapon1()
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
                    GameObject go = Instantiate(bullet1, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    i = 0;
                }
            }
            else if (i == firespeed)
            {
                GameObject go = Instantiate(bullet1, BulletExit.transform.position, Quaternion.identity);
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
                    GameObject go = Instantiate(bullet1, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = -0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    i = 0;
                }
            }
            else if (i == firespeed)
            {
                position.x -= .5f;
                GameObject go = Instantiate(bullet1, BulletExit.transform.position, Quaternion.identity);
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
                GameObject go = (GameObject)Instantiate(bullet1, BulletExit.transform.position, Quaternion.identity);
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
                GameObject go = (GameObject)Instantiate(bullet1, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = -0.1f;
                i = 0;
            }
        }

    }

    public void Weapon2()
    {
        Vector2 position = transform.position;

        //Shoot Right Up
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                GameObject go = Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
                go.GetComponent<BulletComponent>().yspeed = 0.1f;

            }
            else
            {
                GameObject go = Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
            }
        }
        //Shoot Left Up
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                GameObject go = Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = -0.1f;
                go.GetComponent<BulletComponent>().yspeed = 0.1f;

            }
            else
            {
                position.x -= .5f;
                GameObject go = Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = -0.1f;
            }
        }
        //Shoot  Up
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position.y += .2f;
            GameObject go = (GameObject)Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
            go.GetComponent<BulletComponent>().yspeed = 0.1f;
        }
        //Shoot  Down
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y -= .5f;
            GameObject go = (GameObject)Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
            go.GetComponent<BulletComponent>().yspeed = -0.1f;
        }
    }

    public void Weapon3()
    {
        Vector2 position = transform.position;

        //Shoot Right Up
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                GameObject go = Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
                go.GetComponent<BulletComponent>().bulletType = 3;

            }
            else
            {
                GameObject go = Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = 0.1f;
                go.GetComponent<BulletComponent>().bulletType = 3;
            }
        }
        //Shoot Left Up
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                GameObject go = Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = -0.1f;
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
                go.GetComponent<BulletComponent>().bulletType = 3;


            }
            else
            {
                position.x -= .5f;
                GameObject go = Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().xspeed = -0.1f;
                go.GetComponent<BulletComponent>().bulletType = 3;
            }
        }
        //Shoot  Up
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            position.y += .2f;
            GameObject go = (GameObject)Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
            go.GetComponent<BulletComponent>().yspeed = 0.1f;
            go.GetComponent<BulletComponent>().bulletType = 3;
        }
        //Shoot  Down
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y -= .5f;
            GameObject go = (GameObject)Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
            go.GetComponent<BulletComponent>().yspeed = -0.1f;
            go.GetComponent<BulletComponent>().bulletType = 3;
        }


    }
}