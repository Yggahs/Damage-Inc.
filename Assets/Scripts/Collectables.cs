using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int Item;
    public Sprite Weapon2Ammo_1,Weapon3Ammo_2;

    private void Start()
    {
        switch(Item)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = Weapon2Ammo_1;
                name = "Weapon2Ammo";
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = Weapon3Ammo_2;
                name = "Weapon3Ammo";
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var WeaponsScript = collision.GetComponent<WeaponsScript>();
        switch (Item)
        {
            case 1:
                if (WeaponsScript.Weapon2Bullets < WeaponsScript.Weapon2MaxBullets)
                {
                    WeaponsScript.Weapon2Bullets = WeaponsScript.Weapon2MaxBullets;
                    Destroy(gameObject);
                }
                break;

            case 2:
                if (WeaponsScript.Weapon3Bullets < WeaponsScript.Weapon3MaxBullets)
                {
                    WeaponsScript.Weapon3Bullets = WeaponsScript.Weapon3MaxBullets;
                    Destroy(gameObject);
                }
                break;
        }
    }


}
