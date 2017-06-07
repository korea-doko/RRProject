using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillItemData
{
    public int m_id;
    public SkillData m_skillData;
    public TileData m_tileData;
    public bool m_isEnable;

    public SkillItemData(int _id,SkillData _skillData, TileData _tileData)
    {
        m_id = _id;
        m_skillData = _skillData;
        m_tileData = _tileData;
        m_isEnable = true;
    }
    
}
