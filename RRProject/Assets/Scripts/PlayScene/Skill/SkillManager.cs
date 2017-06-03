using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour,IManager
{
    public SkillModel m_model;
    public SkillView m_view;

    static SkillManager m_inst;

    public static SkillManager GetInst
    {
        get { return m_inst; }
    }
    public SkillManager()
    {
        m_inst = this;
    }
  

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<SkillModel>("SkillModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<SkillView>("SkillView", this.gameObject);
        m_view.Init(m_model);
        //m_inst = this;

        //m_skillList = new List<Skill>();

        //for (int i = 0; i < 4; i++)
        //{
        //    int numOfCombo = Random.Range(3, 5);
        //    KeyCode[] code = new KeyCode[numOfCombo];

        //    for (int k = 0; k < numOfCombo; k++)
        //    {
        //        int q = Random.Range(0, 7);
        //        KeyCode key = KeyCode.A;

        //        if (q == 0)
        //            key = KeyCode.A;
        //        else if (q == 1)
        //            key = KeyCode.S;
        //        else if (q == 2)
        //            key = KeyCode.D;
        //        else if (q == 3)
        //            key = KeyCode.W;
        //        else if (q == 4)
        //            key = KeyCode.J;
        //        else if (q == 5)
        //            key = KeyCode.K;
        //        else if (q == 6)
        //            key = KeyCode.L;
        //        else
        //            key = KeyCode.I;


        //        code[k] = key;
        //    }

        //    Skill skill = new Skill("Skill Name" + i.ToString(), code);
        //    m_skillList.Add(skill);
        //}

        //SkillCommandContainerPanel.GetInst.Init(m_skillList);
    }

    public void StartMgr()
    {
        
    }

    public void UpdateMgr()
    {

    }
}
