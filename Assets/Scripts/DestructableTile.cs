using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableTile : MonoBehaviour {
    public bool IsDestructable;

    private void Start()
    {
        IsDestructable = GetComponent<DestructableTileClass>().destructable;
    }

}
