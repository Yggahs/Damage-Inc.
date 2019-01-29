using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : Enemy
{
    private void Update()
    {
        Death();
        Patrol();
    }
}
