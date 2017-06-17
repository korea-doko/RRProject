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
    [SerializeField]
    int m_hp;
    [SerializeField]
    List<SkillData> m_skillDataList;
    [SerializeField]
    int m_sight;
    [SerializeField]
    int m_prevXindex;
    [SerializeField]
    int m_prevYIndex;


    public PlayerData(int _xIndex, int _yIndex)
    {
        m_skillDataList = new List<SkillData>();

        m_xIndex = _xIndex;
        m_yIndex = _yIndex;
        m_parentTileData = MapManager.GetInst.GetTileData(m_xIndex, m_yIndex);

        m_prevXindex = -1;
        m_prevYIndex = -1;

        m_hp = 10;
        m_sight = 3;
    }
    public int HP
    {
        get { return m_hp; }
        set { m_hp = value; }
    }
    public int xIndex
    {
        get { return m_xIndex; }
    }
    public int yIndex
    {
        get { return m_yIndex; }
    }
    public int prevXIndex
    {
        get { return m_prevXindex; }
    }
    public int prevYIndex
    {
        get { return m_prevYIndex; }
    }
    public int Sight
    {
        get { return m_sight; }
    }
    public TileData ParentTileData
    {
        get { return m_parentTileData; }
    }
    public void ChangePosIndex(int _xIndex, int _yIndex)
    {
        m_prevXindex = m_xIndex;
        m_prevYIndex = m_yIndex;

        m_xIndex = _xIndex;
        m_yIndex = _yIndex;

        m_parentTileData = MapManager.GetInst.GetTileData(m_xIndex, m_yIndex);
    }
    public void AddSkillData(SkillData _data)
    {
        m_skillDataList.Add(_data);
    }
    public List<SkillData> SkillDataList
    {
        get { return m_skillDataList; }
    }
}
