using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public int m_id;
    public Tile m_parentTile;
    public SpriteRenderer m_ren;
    public bool m_isActive;


    public void Init(MonsterData _data)
    {
        m_ren = this.GetComponent<SpriteRenderer>();
        m_id = _data.ID;
        SetParentTile(_data.ParentTileData);
    }

    public void SetParentTile(TileData _data)
    {
        m_parentTile = MapManager.GetInst.GetTile(_data);
        this.transform.position = m_parentTile.transform.position;
    }
    public void Disable()
    {
        m_isActive = false;
        this.gameObject.SetActive(m_isActive);
    }
    public void Enable()
    {
        m_isActive = true;
        this.gameObject.SetActive(m_isActive);
    }
}
