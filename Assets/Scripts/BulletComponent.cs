using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour {

    public float xspeed = 0f;
    public float yspeed = 0f;
    public int bulletType;
    float timer;
    int Damage = 1;

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update ()
    {


        timer += Time.deltaTime;


        //Logic for Boomerang shot
        if (bulletType == 3)
        {
            transform.Rotate(new Vector3(0, 0, 20));
            if (timer > 0.5 && timer < 0.55)
            {
                GetComponent<BulletComponent>().yspeed = GetComponent<BulletComponent>().yspeed * -1;
                GetComponent<BulletComponent>().xspeed = GetComponent<BulletComponent>().xspeed * -1;
                
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x += xspeed;
        position.y += yspeed;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy EnemyComponent = other.GetComponent<Enemy>();

        if (EnemyComponent is Enemy && other == other.GetComponent<BoxCollider2D>())
        {
            other.GetComponent<Enemy>().TakeDamage(Damage);
            Destroy(gameObject);   
        }
    }
}
