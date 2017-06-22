using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public Tile m_parentTile;

    
    public void Init(PlayerData _data)
    {
        m_parentTile = MapManager.GetInst.GetTile(_data.ParentTileData);
        this.transform.position = m_parentTile.transform.position;
    }
}
