using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerModel : MonoBehaviour
{
    public PlayerData m_playerData;
    public List<BSkillData> m_bSkillDataList;

    public bool m_isModelChanged;
    
    public void Init()
    {
        m_isModelChanged = true;
        m_bSkillDataList = new List<BSkillData>();
    }

    public void AddBSkillToBPlayerData(BSkillData _data)
    {
        m_bSkillDataList.Add(_data);
    }
    
    public void Clear()
    {
        m_bSkillDataList.Clear();
    }
}
