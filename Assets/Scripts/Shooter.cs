using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy {

    public AudioClip DeathClip;

    void Update ()
    {
        Patrol();
        Shoot();
        Death(DeathClip);
    }
}
