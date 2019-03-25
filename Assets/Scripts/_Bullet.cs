using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Bullet : MonoBehaviour {
    GameObject PlayerRef;
    GameObject EnemyRef;

    
    private void DestroyBullet()
    {
        Destroy(gameObject, 1f);
    }
}
