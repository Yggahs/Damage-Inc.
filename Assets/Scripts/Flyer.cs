using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : Enemy
{
    public AudioClip DeathClip;

    // Update is called once per frame
    void Update()
    {
        Fly();
        Death(DeathClip);
    }
}
