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
    [SerializeField]
    bool m_isSeen;


    public MonsterData(int _id,int _xIndex,int _yIndex, int _hp)
    {
        m_id = _id;
        m_hp = _hp;
        m_isDead = false;
        m_isSeen = false;
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
    public bool IsSeen
    {
        get { return m_isSeen; }
        set { m_isSeen = value; }                                      
    }
    public void ChangePosIndex(int _xIndex, int _yIndex)
    {
        m_xIndex = _xIndex;
        m_yIndex = _yIndex;

        m_parentTileData = MapManager.GetInst.GetTileData(m_xIndex, m_yIndex);

        if (FOWManager.GetInst.m_model.m_fowTileDataAry[m_xIndex][m_yIndex].m_state == FOWTileState.Visiting)
            IsSeen = true;
        else
            IsSeen = false;
        
    }
}
