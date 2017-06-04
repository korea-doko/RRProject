using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField]
    int m_xIndex;
    [SerializeField]
    int m_yIndex;
    [SerializeField]
    TileData m_parentTileData;


    public PlayerData(int _xIndex, int _yIndex)
    {
        m_xIndex = _xIndex;
        m_yIndex = _yIndex;
        m_parentTileData = MapManager.GetInst.GetTileData(m_xIndex, m_yIndex);
    }
    public int xIndex
    {
        get { return m_xIndex; }
        set { m_xIndex = value; }
    }
    public int yIndex
    {
        get { return m_yIndex; }
        set { m_yIndex = value; }
    }
    public TileData ParentTileData
    {
        get { return m_parentTileData; }
        set { m_parentTileData = value; }
    }
}
