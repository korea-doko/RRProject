using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanel : MonoBehaviour
{
    public int m_numOfSkill;
    public List<Text> m_skillTextList;
    
    public void Init(BPlayerModel _model)
    {
        InitSkillPanel();

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

        string str = _data.Name + " : ";
        for (int i = 0; i < _data.m_commandList.Count; i++)
            str += _data.m_commandList[i].m_code.ToString() + "(" + _data.m_commandList[i].m_property.ToString() + ") ";

        t.text = str;
        t.gameObject.SetActive(true);        
    }

    void InitSkillPanel()
    {
        Text[] texts = this.GetComponentsInChildren<Text>();

        for (int i = 0; i < texts.Length; i++)
            m_skillTextList.Add(texts[i]);

        Clear();
    }

}
