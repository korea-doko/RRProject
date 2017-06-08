using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterData
{
    [SerializeField]
    int m_id;
    [SerializeField]
    int m_xIndex;
    [SerializeField]
    int m_yIndex;
    [SerializeField]
    TileData m_parentTileData;
    [SerializeField]
    int m_hp;
    [SerializeField]
    bool m_isDead;


    public MonsterData(int _id,int _xIndex,int _yIndex, int _hp)
    {
        m_id = _id;
        m_hp = _hp;
        m_isDead = false;
        ChangePosIndex(_xIndex, _yIndex);
    }

    public void ChangeMonsterData(BMonsterData _data)
    {
        m_hp = _data.m_hp;
        if (m_hp <= 0)
            m_isDead = true;
    }

    public int ID
    {
        get { return m_id; }
    }
    public int xIndex
    {
        get { return m_xIndex; }
    }
    public int yIndex
    {
        get { return m_yIndex; }
    }
    public TileData ParentTileData
    {
        get { return m_parentTileData; }
    }
    public int HP
    {
        get { return m_hp; }
    }
    public bool IsAlive
    {
        get { return !m_isDead; }
    }

    public void ChangePosIndex(int _xIndex, int _yIndex)
    {
        m_xIndex = _xIndex;
        m_yIndex = _yIndex;

        m_parentTileData = MapManager.GetInst.GetTileData(m_xIndex, m_yIndex);
    }
}
