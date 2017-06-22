using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMonsterModel : MonoBehaviour {

    public bool m_isModelChanged;
    public List<MonsterData> m_monsterDataList;

    public void Init()
    {
        m_isModelChanged = true;

        m_monsterDataList = new List<MonsterData>();
    }

 
    public void GetDamage(int _damage)
    {        
        for(int i = 0; i < m_monsterDataList.Count;i++)
        {
            MonsterData data = m_monsterDataList[i];
            data.CurHP -= _damage;

            break;
        }
        m_isModelChanged = true;
    }

    public int GetMonsterCurHP()
    {
        // 일단 그냥 0번 놈의 데이터가져다가 쓰자
        return m_monsterDataList[0].CurHP;
    }

    public void SceneChanged()
    {
        m_monsterDataList.Clear();
    }
}
