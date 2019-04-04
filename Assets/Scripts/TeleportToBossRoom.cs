using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToBossRoom : MonoBehaviour {
    public GameObject PlayerRef;
    public GameObject BossRoomEntrace;
    public GameObject Boss;
    public GameObject prompt;
    private void Start()
    {
        prompt.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        prompt.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerRef.transform.position = BossRoomEntrace.transform.position;
            Instantiate(Boss, new Vector3(-149.76f, 82.96f, 0),Quaternion.identity);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
    }
}
