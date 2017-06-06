﻿using System.Collections;
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


    public PlayerData(int _xIndex, int _yIndex)
    {
        m_skillDataList = new List<SkillData>();

        m_xIndex = _xIndex;
        m_yIndex = _yIndex;
        m_parentTileData = MapManager.GetInst.GetTileData(m_xIndex, m_yIndex);

        m_hp = 10;
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
    public void AddSkillData(SkillData _data)
    {
        m_skillDataList.Add(_data);
    }
    public List<SkillData> SkillDataList
    {
        get { return m_skillDataList; }
    }
}
