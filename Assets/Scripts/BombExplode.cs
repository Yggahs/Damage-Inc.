using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour {



    public GameObject Explosion;
    float time = 0f;




    // Use this for initialization
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 3f)
        {
            Debug.Log("EXPLOSION!");
            Instantiate(Explosion, GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
