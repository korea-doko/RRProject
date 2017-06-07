using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    public int m_numOfSkill;
    public List<Text> m_skillTextList;
    
    public void Init()
    {
        m_numOfSkill = 0;
        Text[] texts = this.GetComponentsInChildren<Text>();

        for(int i = 0; i<texts.Length;i++)
            m_skillTextList.Add(texts[i]);

        Clear();
    }

    public void Clear()
    {
        m_numOfSkill = 0;

        for (int i = 0; i < m_skillTextList.Count; i++)
            m_skillTextList[i].gameObject.SetActive(false);
    }
    public void Show(SkillData _data)
    {
        Text t = m_skillTextList[m_numOfSkill++];

        string str = _data.m_name + " : ";
        for (int i = 0; i < _data.m_comboList.Count; i++)
            str += _data.m_comboList[i].ToString() + " ";

        t.text = str;
        t.gameObject.SetActive(true);

        m_numOfSkill++;
    }
}
