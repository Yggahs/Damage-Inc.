using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprinter : Enemy
{
    // Update is called once per frame
    void Update()
    {
        Death();
    }

    private void FixedUpdate()
    {
        Sprint();
    }
}
