using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BarDir
{
    Right,
    Left
}

[System.Serializable]
public class BarData
{
    public int m_id;
    public BarDir m_dir;    
    public bool m_isActive;         // 이 bar 데이터는 현재 움직이고 있는가?
    public float m_speed;
    public BarType m_type;
    public SkillPropertyName m_skillPropertyName;

    public BarData(int _id)
    {
        m_id = _id;
        m_isActive = false;
        m_speed = 300.0f;
        m_type = BarType.Normal;
        m_skillPropertyName = SkillPropertyName.None;
    }

    public void Activate(BarType _barType,BarDir _dir)
    {
        m_isActive = true;
        m_dir = _dir;
        m_type = _barType;

        if( m_type == BarType.Touchable)
        {
            m_skillPropertyName = SkillPropertyName.None;
        }
        else if (m_type == BarType.Untouchable)
        {

            m_skillPropertyName = SkillPropertyName.None;
        }
        else
        {
            m_skillPropertyName = (SkillPropertyName)UnityEngine.Random.Range(0, 3);
        }
    }

    public void Clear()
    {
        m_isActive = false;
        m_speed = 300.0f;
        m_type = BarType.Normal;
        m_skillPropertyName = SkillPropertyName.None;
    }
}
