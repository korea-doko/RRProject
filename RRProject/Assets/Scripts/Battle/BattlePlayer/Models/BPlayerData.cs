using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BPlayerData
{
    public int m_hp;
    public List<BSkillData> m_bSkillDataList;

    public BPlayerData()
    {
        m_bSkillDataList = new List<BSkillData>();

        m_hp = -1;

    }
    public void Clear()
    {
        for (int i = 0; i < m_bSkillDataList.Count; i++)
            m_bSkillDataList[i].Clear();
    }
}
