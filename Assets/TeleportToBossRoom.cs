using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToBossRoom : MonoBehaviour {
    public GameObject PlayerRef;
    public GameObject BossRoomEntrace;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerRef.transform.position = BossRoomEntrace.transform.position;
        }
    }
}
