using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterSpriteType
{
    Normal
}
public class MonsterModel : MonoBehaviour
{
    public List<MonsterData> m_monsterDataList;
    public int m_numOfMon;

    public List<Sprite> m_monsterSpriteList;

    public void Init()
    {
        InitVariables();

        InitSpriteList();

        InitMonsterData();
    }

    public Sprite GetMonsterSprite(MonsterSpriteType _type)
    {
        return m_monsterSpriteList[(int)_type];
    }

    void InitVariables()
    {
        m_numOfMon = 10;
    }
    void InitSpriteList()
    {
        m_monsterSpriteList = new List<Sprite>();

        int numOfSprite = System.Enum.GetNames(typeof(MonsterSpriteType)).Length;

        for (int i = 0; i < numOfSprite; i++)
        {
            Sprite sp = Resources.Load<Sprite>("PlayScene/Images/Monsters/" + ((MonsterSpriteType)i).ToString());
            m_monsterSpriteList.Add(sp);
        }
    }
    void InitMonsterData()
    {
        m_monsterDataList = new List<MonsterData>();

        for (int i = 0; i < m_numOfMon; i++)
        {
            TileData data = MapManager.GetInst.GetValidRandomTileData();
            int ranHP = UnityEngine.Random.Range(10, 20);
            m_monsterDataList.Add(new MonsterData(i,data.m_xIndex, data.m_yIndex,ranHP));
        }
    }
  
}
