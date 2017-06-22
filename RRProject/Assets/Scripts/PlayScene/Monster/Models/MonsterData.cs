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
    [SerializeField]
    int m_level;
    [SerializeField]
    List<TitleData> m_titleList;

    [SerializeField]
    int m_curHP;

    [SerializeField]
    int m_hpRegenRate;

    [SerializeField]
    int m_damage;





    public MonsterData(int _id,int _xIndex,int _yIndex, int _hp)
    {
        m_titleList = new List<TitleData>();

        m_id = _id;
        m_hp = _hp;
        m_curHP = m_hp;

        m_isDead = false;
        m_isSeen = false;

        m_hpRegenRate = 1;
        m_damage = 1;

        m_level = UnityEngine.Random.Range(0, System.Enum.GetNames(typeof(MonsterSpriteType)).Length);
        ChangePosIndex(_xIndex, _yIndex);
    }
    public void AddTitle(TitleData _data)
    {
        m_titleList.Add(_data);
    }
    public void ChangeMonsterData(MonsterData _data)
    {
        m_hp = _data.m_hp;

        if (m_hp <= 0)
        {           
            m_isDead = true;
            m_isSeen = false;
        }
    }

    public int CurHP
    {
        get { return m_curHP; }
        set { m_curHP = value; }
    }
    public int HPRegenRate
    {
        get { return m_hpRegenRate; }
        set { m_hpRegenRate = value; }
    }
    public int Damage
    {
        get { return m_damage; }
        set { m_damage = value; }
    }
    public List<TitleData> GetTitleList
    {
        get { return m_titleList; }
    }
    public int Level
    {
        get
        {
            return m_level;
        }
        set
        {
            m_level = value;
        }
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
        set { m_hp = value; }
    }
    public bool IsDead
    {
        get { return m_isDead; }
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
