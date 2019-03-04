using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeaponsScript : MonoBehaviour
{
    int i = 0, firespeed = 10;
    public GameObject bullet1, bullet2, bullet3;
    public GameObject BulletExit;
    float timer;
    public int Weapon1Bullets, Weapon2Bullets, Weapon3Bullets;
    public int Weapon1MaxBullets = 20, Weapon2MaxBullets = 20, Weapon3MaxBullets = 20;
    public Text MagazineText;

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
        UpdateCanvasWeapon();
    }

    public void Weapon2()
    {
        Vector2 position = transform.position;

        if (Weapon2Bullets > 0)
        {
            //Shoot Right Up
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                    GameObject go = Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    Weapon2Bullets--;
                }
                else
                {
                    GameObject go = Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    Weapon2Bullets--;
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
                    Weapon2Bullets--;
                }
                else
                {
                    position.x -= .5f;
                    GameObject go = Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = -0.1f;
                    Weapon2Bullets--;
                }
            }
            //Shoot  Up
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                position.y += .2f;
                GameObject go = (GameObject)Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
                Weapon2Bullets--;
            }
            //Shoot  Down
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                position.y -= .5f;
                GameObject go = (GameObject)Instantiate(bullet2, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = -0.1f;
                Weapon2Bullets--;
            }
            
        }
        UpdateCanvasWeapon();
    }

    public void Weapon3()
    {
        Vector2 position = transform.position;
        if (Weapon3Bullets > 0)
        {
            //Shoot Right Up
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                    GameObject go = Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    go.GetComponent<BulletComponent>().yspeed = 0.1f;
                    go.GetComponent<BulletComponent>().bulletType = 3;
                    Weapon3Bullets--;

                }
                else
                {
                    GameObject go = Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = 0.1f;
                    go.GetComponent<BulletComponent>().bulletType = 3;
                    Weapon3Bullets--;
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
                    Weapon3Bullets--;

                }
                else
                {
                    position.x -= .5f;
                    GameObject go = Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                    go.GetComponent<BulletComponent>().xspeed = -0.1f;
                    go.GetComponent<BulletComponent>().bulletType = 3;
                    Weapon3Bullets--;
                }
            }
            //Shoot  Up
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                position.y += .2f;
                GameObject go = (GameObject)Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = 0.1f;
                go.GetComponent<BulletComponent>().bulletType = 3;
                Weapon3Bullets--;
            }
            //Shoot  Down
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                position.y -= .5f;
                GameObject go = (GameObject)Instantiate(bullet3, BulletExit.transform.position, Quaternion.identity);
                go.GetComponent<BulletComponent>().yspeed = -0.1f;
                go.GetComponent<BulletComponent>().bulletType = 3;
                Weapon3Bullets--;
            }
            
        }
        UpdateCanvasWeapon();
    }
    
    private void UpdateCanvasWeapon()
    {
        var selectedWeapon = GetComponent<CharacterController2D>().selectedWeapon;

        switch (selectedWeapon)
        {
            case 1:
                MagazineText.text = "∞";
                break;

            case 2:
                MagazineText.text = Weapon2Bullets.ToString() + "/" + Weapon2MaxBullets.ToString();
                break;

            case 3:
                MagazineText.text = Weapon3Bullets.ToString() + "/" + Weapon3MaxBullets.ToString();
                print("kek");
                break;

            default:
                MagazineText.text = "∞";
                break;
        }
    }
}