using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<Skill> m_skillList;

    public static SkillManager m_inst;
    public static SkillManager GetInst
    {
        get { return m_inst; }
    }

    private void Start()
    {
        m_inst = this;

        m_skillList = new List<Skill>();

        Skill fire = new Skill("FireBall", KeyCode.A, KeyCode.A, KeyCode.K);
        Skill ice = new Skill("Ice", KeyCode.A, KeyCode.A, KeyCode.K,KeyCode.A);
        Skill wind = new Skill("Wind", KeyCode.K, KeyCode.K, KeyCode.W);

        m_skillList.Add(fire);
        m_skillList.Add(ice);
        m_skillList.Add(wind);
    }

    public void CheckCombo(KeyCode _code)
    {
        for(int i = 0; i < m_skillList.Count;i++)
        {
            Skill s = m_skillList[i];

            s.CheckCombo(_code);
        }            
    }
    public void ClearCombo()
    {
        for(int i = 0; i < m_skillList.Count;i++)
        {
            Skill s = m_skillList[i];
            s.ClearCombo();
        }
    }
}
