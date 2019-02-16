using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : Enemy
{
    // Update is called once per frame
    void Update()
    {
        Fly();
        Death();
    }
}
