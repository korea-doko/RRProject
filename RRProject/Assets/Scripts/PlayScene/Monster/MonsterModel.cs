using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterSpriteType
{
    Yellow,
    Ivory,
    Purple,
    Blue
}
public class MonsterModel : MonoBehaviour
{
    public List<MonsterData> m_monsterDataList;
    public int m_numOfMon;
    

    public void Init()
    {
        InitVariables();    
        InitMonsterData();
    }

    public Sprite GetMonsterSprite(MonsterSpriteType _type)
    {
        Sprite sp = ResourceManager.GetInst.GetSprite(ResourceType.Monster, (int)_type);
        return sp;
    }

    void InitVariables()
    {
        m_numOfMon = 80;
    }    
    void InitMonsterData()
    {
        m_monsterDataList = new List<MonsterData>();

        TitleGenerator titleGenerator = new TitleGenerator();

        for (int i = 0; i < m_numOfMon; i++)
        {
            TileData data = MapManager.GetInst.GetValidRandomTileData();
            int ranHP = UnityEngine.Random.Range(100, 200);

            MonsterData monData = new MonsterData(i, data.m_xIndex, data.m_yIndex, ranHP);

            for(int k = 0; k < monData.Level;k++)
            {
                TitleData titleData = titleGenerator.GetRandomTitle();
                monData.AddTitle(titleData);
            }

            m_monsterDataList.Add(monData);
        }
    } 
}
