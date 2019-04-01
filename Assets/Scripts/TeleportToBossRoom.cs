using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToBossRoom : MonoBehaviour {
    public GameObject PlayerRef;
    public GameObject BossRoomEntrace;
    public GameObject Boss;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerRef.transform.position = BossRoomEntrace.transform.position;
            Instantiate(Boss, new Vector3(-150,80,0),Quaternion.identity);
        }
    }
}
