using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour {
    public GameObject Bomb;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(Bomb, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        }
    }
}
