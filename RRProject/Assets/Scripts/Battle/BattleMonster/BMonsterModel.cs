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

}
