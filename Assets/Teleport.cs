using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public bool discovered = false;
    GameObject[] Teleporters = new GameObject[5];
    Vector3[] TeleporterPosition = new Vector3[5];
    int i = 0;
	// Use this for initialization
	void Start () {
        Teleporters = GameObject.FindGameObjectsWithTag("Teleporter");
        
        //for (i=0; i <= 1; i++)
        //{
            
        //}
		//foreach(GameObject Teleporter in Teleporters)
  //      {
  //          TeleporterPosition[i] = Teleporter.transform.position;
  //          i++;
  //      }
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

                collision.gameObject.transform.position = Teleporters[0].transform.position;
            }
        }
    }
}
