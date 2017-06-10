using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerModel : MonoBehaviour
{
    public BPlayerData m_playerData;
    public bool m_isModelChanged;
    
    public void Init()
    {
        m_playerData = new BPlayerData();
        m_isModelChanged = true;
    }

    public void AddBSkillToBPlayerData(BSkillData _data)
    {
        m_playerData.m_bSkillDataList.Add(_data);
    }
    
    public void Clear()
    {
        m_playerData.m_bSkillDataList.Clear();
    }
}
