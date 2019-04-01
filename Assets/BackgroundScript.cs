using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {
   
    public GameObject PlayerRef;
    public float bgSpeed;
    public Renderer bgRend = null;
    private Camera cam;

    public Material forest;
    public Material lab;
    public Material offices;
    // Update is called once per frame
    private void Start()
    {
        cam = Camera.main;
       
    }
    void Update () {
        
        transform.localScale = new Vector3(cam.orthographicSize * 2.0f * Screen.width / Screen.height, cam.orthographicSize * 2.0f, 0.1f);
        if (PlayerRef.GetComponent<Rigidbody2D>().velocity.x>0 || PlayerRef.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            bgRend.material.mainTextureOffset += new Vector2(bgSpeed * PlayerRef.GetComponent<CharacterController2D>().backgroundSpeed * Time.deltaTime * 0.2f, 0f);
        }
    }
}
