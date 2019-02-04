using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy {	
	
	void Update ()
    {
        Patrol();
        Shoot();
        Death();	
	}
}
