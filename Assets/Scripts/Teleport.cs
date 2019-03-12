using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    Canvas canvas;
    public GameObject TeleportMenu;
    public bool discovered = false;
    GameObject Traveller;
    GameObject[] Teleporters = new GameObject[5];
    Vector3[] TeleporterPosition = new Vector3[5];
    int i = 0;
    int TeleID = 0;
	// Use this for initialization
	void Start ()
    {
        Teleporters = GameObject.FindGameObjectsWithTag("Teleporter");
        canvas = FindObjectOfType<Canvas>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("player") && !discovered)
        {
            discovered = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("player") && discovered)
        {
            Traveller = collision.gameObject;
            if (Input.GetKeyDown(KeyCode.W))
            {
                Instantiate(TeleportMenu,transform.position,Quaternion.identity,canvas.transform);               
            }
        }
    }

    public void TeleportToTarget(GameObject Traveller)
    {
            TeleID = 1;
            Traveller.transform.position = Teleporters[TeleID].transform.position;
            Destroy(TeleportMenu.gameObject);
    }

    public void ReturnToGame()
    {
        Destroy(TeleportMenu.gameObject);
    }
    
}
