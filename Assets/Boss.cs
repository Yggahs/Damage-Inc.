using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    Transform arm1;
    Transform arm2;
    private void Start()
    {
        arm1 = transform.GetChild(0);
        arm2 = transform.GetChild(1);
    }
    // Update is called once per frame
    void Update () {

        //Debug.Log(arm1.name);
        //Debug.Log(arm2.name);
	}
}
