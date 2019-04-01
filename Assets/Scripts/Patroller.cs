using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : Enemy
{
    public AudioClip DeathClip;

    private void Update()
    {            
        Patrol();
        Death(DeathClip);
    }
}
