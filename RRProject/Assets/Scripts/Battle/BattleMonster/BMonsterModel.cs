using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMonsterModel : MonoBehaviour {

    public bool m_isModelChanged;
    public List<BMonsterData> m_bMonsterDataList;

    public void Init()
    {
        m_isModelChanged = true;

        m_bMonsterDataList = new List<BMonsterData>();

        for (int i = 0; i < 10; i++)
            m_bMonsterDataList.Add(new BMonsterData());
    }

    public BMonsterData GetEnableData()
    {
        for(int i = 0; i < m_bMonsterDataList.Count;i++)
        {
            if (!m_bMonsterDataList[i].m_isInit)
                return m_bMonsterDataList[i];

            if( i == m_bMonsterDataList.Count -1)
            {
                for (int k = 0; k < 10; k++)
                    m_bMonsterDataList.Add(new BMonsterData());

                continue;
            }
        }

        Debug.Log("나올수 없음");
        return null;
    }
    public void GetDamage(int _damage)
    {
        // 여기서는 어떻게 나누는지 상관없이 그냥 다 똑같이 데미지 받는다

        for(int i = 0; i < m_bMonsterDataList.Count;i++)
        {
            
            BMonsterData bData = m_bMonsterDataList[i];

            if (bData.m_isInit)
            {
                bData.m_hp -= _damage;
            }
            else
                break;
        }

        m_isModelChanged = true;
    }
    public int GetMonsterHP()
    {
        // 일단 그냥 0번 놈의 데이터가져다가 쓰자
        return m_bMonsterDataList[0].m_hp;
    }

    public void SceneChanged()
    {
        for (int i = 0; i < m_bMonsterDataList.Count; i++)
            m_bMonsterDataList[i].Clear();

    }
}
