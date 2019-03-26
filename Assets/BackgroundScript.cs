using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {
   
    public GameObject PlayerRef;
    public float bgSpeed;
    public Renderer bgRend = null;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed*PlayerRef.GetComponent<CharacterController2D>().backgroundSpeed*Time.deltaTime,0f);
	}
}
