using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public Tile m_parentTile;

    public void Init(MonsterData _data)
    {
        SetParentTile(_data.ParentTileData);
    }

    public void SetParentTile(TileData _data)
    {
        m_parentTile = MapManager.GetInst.GetTile(_data);
        this.transform.position = m_parentTile.transform.position;
    }
}
