﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Enemy
{

    private void Awake()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
    private void FixedUpdate()
    {
        Crawl();
        Death();
    }
}
