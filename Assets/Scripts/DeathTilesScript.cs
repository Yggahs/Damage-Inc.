using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTilesScript : MonoBehaviour {

    public bool DoesKill;

    private void Start()
    {
        DoesKill = GetComponent<DeathTileClass>().Kills;
    }

}
