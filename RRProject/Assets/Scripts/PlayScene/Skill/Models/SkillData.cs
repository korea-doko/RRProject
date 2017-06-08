using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillPropertyName
{
    None,
    Black,
    Green,
    Yellow
}

[System.Serializable]
public struct ComboWithProperty
{
    public KeyCode m_code;
    public SkillPropertyName m_property;
    public bool m_isColorMatch;

    public ComboWithProperty(KeyCode _code, SkillPropertyName _property = SkillPropertyName.None)
    {
        m_code = _code;
        m_property = _property;
        m_isColorMatch = false;
    }
    public bool CheckCombo(KeyCode _code, SkillPropertyName _name)
    {
        if (m_code == _code)
        {
            if (m_property == _name)
                m_isColorMatch = true;

            return true;
        }
        return false;
    }
    public void Clear()
    {
        m_isColorMatch = false;
    }
}
[System.Serializable]
public class SkillData
{
    public string m_name;
    public List<ComboWithProperty> m_comboList;
    public int m_comboCount;

    public SkillData(string _name, params KeyCode[] _param)
    {
        m_name = _name;
        m_comboList = new List<ComboWithProperty>();

        int numOfSPN = System.Enum.GetNames(typeof(SkillPropertyName)).Length;

        for (int i = 0; i < _param.Length; i++)
        {
            SkillPropertyName spn = (SkillPropertyName)UnityEngine.Random.Range(0, numOfSPN); 
            ComboWithProperty cwp = new ComboWithProperty(_param[i],spn);
            m_comboList.Add(cwp);
        }

        m_comboCount = 0;
    }

    public bool CheckCombo(KeyCode _code,SkillPropertyName _name)
    {
        ComboWithProperty cwp = m_comboList[m_comboCount];

        if (cwp.CheckCombo(_code, _name))
        {
            m_comboCount++;

            if (m_comboCount == m_comboList.Count)
            {
                m_comboCount = 0;
                return true;
            }            
            return false;
        }
        else
        {            
            ClearCombo();
            return false;
        }
    }   
    
    public void ClearCombo()
    {
        m_comboCount = 0;

        for (int i = 0; i < m_comboList.Count; i++)
            m_comboList[i].Clear();

    }
    int GetMatchedColor()
    {
        int num = 0;
        for(int i = 0; i < m_comboList.Count;i++)
        {
            if (m_comboList[i].m_isColorMatch)
                num++;
        }
        return num;
    }

    public void Cast()
    {
        // 일단 스킬 맞추면 데미지 10을 주자. 
    }
}
