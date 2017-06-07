using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BPlayerData
{
    public bool m_isInit;
    public int m_hp;
    public List<SkillData> m_skillDataList;

    public BPlayerData()
    {
        m_skillDataList = new List<SkillData>();
        m_isInit = false;
        m_hp = -1;
    }
    public void SetData(PlayerData _data)
    {
        m_isInit = true;
        m_hp = _data.HP;
        m_skillDataList = _data.SkillDataList;
    }

    public void Clear()
    {
        m_isInit = false;
    }
}
