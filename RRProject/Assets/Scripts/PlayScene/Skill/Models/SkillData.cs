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


public interface ISkill
{
    void Cast();
}
[System.Serializable]
public class SkillData
{
    public string m_name;
    public List<KeycodeWithProperty> m_commandList;
    public ISkill m_iSkill;

    public SkillData(string _name, params KeyCode[] _param)
    {
        m_name = _name;
        m_commandList = new List<KeycodeWithProperty>();
    
        int numOfSPN = System.Enum.GetNames(typeof(SkillPropertyName)).Length;

        for (int i = 0; i < _param.Length; i++)
        {
            SkillPropertyName spn = (SkillPropertyName)UnityEngine.Random.Range(0, numOfSPN); 
            KeycodeWithProperty cwp = new KeycodeWithProperty(_param[i],spn);
            m_commandList.Add(cwp);
        }        
    }
    public void Cast()
    {
        // 일단 스킬 맞추면 데미지 10을 주자. 
        m_iSkill.Cast();
    }
}
