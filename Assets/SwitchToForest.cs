using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToForest : SwitchZone {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SwitchToForest();
    }

}
