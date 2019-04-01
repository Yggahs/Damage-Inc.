using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinter : Enemy
{
    Animator animatore;
    public AudioClip DeathClip;
    private bool animator;

    private void Awake()
    {
        animator = GetComponent<SpriteRenderer>().flipX;
        animatore = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Death(DeathClip);
    }
    

    private void FixedUpdate()
    {
        Sprint();

        if (facing.x >= 0) animator = false;
        else if (facing.x < 0) animator = true;


        animatore.SetBool("isFacingRight", animator);
        animatore.SetBool("TargetAcquired", TargetAcquired);
    }
}

