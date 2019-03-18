using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int Item;
    public Sprite Weapon2Ammo_1,Weapon3Ammo_2, HealthRefill_3, HeartsIncrease_4, UnlockWeapon2_5, UnlockWeapon3_6, UnlockBombs_7, BombsRefill_8;
    public GameObject Player;

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
            case 3:
                GetComponent<SpriteRenderer>().sprite = HealthRefill_3;
                name = "HealthRefill";
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = HeartsIncrease_4;
                name = "HeartsIncrease";
                break;
            case 5:
                GetComponent<SpriteRenderer>().sprite = UnlockWeapon2_5;
                name = "UnlockWeapon2";
                break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = UnlockWeapon3_6;
                name = "UnlockWeapon3";
                break;
            case 7:
                GetComponent<SpriteRenderer>().sprite = UnlockBombs_7;
                name = "UnlockBombs";
                break;
            case 8:
                GetComponent<SpriteRenderer>().sprite = BombsRefill_8;
                name = "BombsRefill";
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var WeaponsScript = collision.GetComponent<WeaponsScript>();
        var CharacterController2DScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<CharacterController2D>();
        var DropBombScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<DropBomb>();


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

            case 3:
                if (CharacterController2DScript.health < CharacterController2DScript.maxHealth)
                {
                    CharacterController2DScript.health = CharacterController2DScript.maxHealth;
                    Destroy(gameObject);
                }
                break;
            case 4:
                if (CharacterController2DScript.hearts < CharacterController2DScript.maxHeartAmount)
                {
                    CharacterController2DScript.hearts++;
                    CharacterController2DScript.maxHealth = CharacterController2DScript.hearts * CharacterController2DScript.healthPerHeart;
                    CharacterController2DScript.health = CharacterController2DScript.maxHealth;
                    Destroy(gameObject);
                }
                break;
            case 5:
                if (CharacterController2DScript.weapon2Unlocked == false)
                {
                    CharacterController2DScript.weapon2Unlocked = true;
                    CharacterController2DScript.selectedWeapon = 2;
                    CharacterController2DScript.ActiveWeaponSprite.sprite = CharacterController2DScript.BSprite2;
                    Destroy(gameObject);
                }
                break;
            case 6:
                if (CharacterController2DScript.weapon3Unlocked == false)
                {
                    CharacterController2DScript.weapon3Unlocked = true;
                    CharacterController2DScript.selectedWeapon = 3;
                    CharacterController2DScript.ActiveWeaponSprite.sprite = CharacterController2DScript.BSprite3;
                    Destroy(gameObject);
                }
                break;
            case 7:
                if (DropBombScript.bombUnlocked == false)
                {
                    DropBombScript.bombUnlocked = true;
                    Destroy(gameObject);
                }
                break;
            case 8:
                if (DropBombScript.bombs < DropBombScript.maxBombs)
                {
                    DropBombScript.bombs = DropBombScript.maxBombs;
                    Destroy(gameObject);
                }
                break;
        }
    }


}
