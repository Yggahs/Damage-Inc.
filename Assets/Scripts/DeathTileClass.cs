using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu()]
public class DeathTileClass : TileBase
{
    public string objectName = "New Death Tile";
    public bool Kills = true;

    public Sprite m_Sprite;
    public GameObject m_Prefab;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
    {
        //tileData.sprite = m_Sprite;
        tileData.gameObject = m_Prefab;

    }

    public override bool StartUp(Vector3Int location, ITilemap tilemap, GameObject go)
    {

        if (go != null)
        {
            go.GetComponent<SpriteRenderer>().sprite = m_Sprite;
            go.transform.position = location + tilemap.GetComponent<Tilemap>().tileAnchor;
        }
        return true;
    }



}
