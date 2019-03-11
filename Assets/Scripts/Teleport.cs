using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public GameObject TeleportMenu;
    public bool discovered = false;
    GameObject[] Teleporters = new GameObject[5];
    Vector3[] TeleporterPosition = new Vector3[5];
    int i = 0;
    int TeleID = 0;
	// Use this for initialization
	void Start ()
    {
        Teleporters = GameObject.FindGameObjectsWithTag("Teleporter");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("player") && !discovered)
        {
            discovered = true;
            Debug.Log("You discovered a teleporter!");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("player") && discovered)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                TeleportMenu.SetActive(true);
                //set teleport menu active
                //TeleportToTarget(collision, TeleID);
            }
        }
    }

    public void TeleportToTarget(Collider2D collision,int TeleID)
    {
            collision.gameObject.transform.position = Teleporters[TeleID].transform.position;
    }
}
