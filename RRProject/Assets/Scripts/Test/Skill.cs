using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill  
{
    public string m_name;
    public List<KeyCode> m_comboList;
    public int m_comboCount;
	
    public Skill( string _name , params KeyCode[] _param)
    {
        m_name = _name;

        m_comboList = new List<KeyCode>();
        for(int i = 0; i < _param.Length;i++)
            m_comboList.Add(_param[i]);

        m_comboCount = 0;
    }

    public bool CheckCombo(KeyCode _code)
    {
        KeyCode code = m_comboList[m_comboCount];
        
        if( code == _code)
        {
            m_comboCount++;

            if( m_comboList.Count  == m_comboCount)
            {
                Debug.Log(m_name + "Combo!!!!");
                m_comboCount = 0;
                return true;
            }
        }
        else
        {
            m_comboCount = 0;
        }

        return false;
    }
    
    public void ClearCombo()
    {
        m_comboCount = 0;
    }
}
