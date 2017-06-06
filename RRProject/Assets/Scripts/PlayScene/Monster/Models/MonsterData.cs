using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterData
{
    [SerializeField]
    int m_xIndex;
    [SerializeField]
    int m_yIndex;
    [SerializeField]
    TileData m_parentTileData;
    [SerializeField]
    int m_hp;

    public MonsterData(int _xIndex,int _yIndex, int _hp)
    {
        m_hp = _hp; 

        ChangePosIndex(_xIndex, _yIndex);
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
    
    public void ChangePosIndex(int _xIndex, int _yIndex)
    {
        m_xIndex = _xIndex;
        m_yIndex = _yIndex;

        m_parentTileData = MapManager.GetInst.GetTileData(m_xIndex, m_yIndex);
    }
}
