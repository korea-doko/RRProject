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
    }

    public void StartMgr()
    {
        
    }
    public void UpdateMgr()
    {

    }
    public void SceneChanged()
    {

    }

    public void CheckSkillItemExists(TileData _data)
    {
        for(int i = 0; i < m_model.m_skillItemDataList.Count;i++)
        {
            SkillItemData sid = m_model.m_skillItemDataList[i];

            if (!sid.m_isEnable)
                continue;

            if (_data.m_xIndex == sid.m_tileData.m_xIndex && _data.m_yIndex == sid.m_tileData.m_yIndex)
            {
                sid.m_isEnable = false;
                PlayerManager.GetInst.m_model.m_playerData.AddSkillData(sid.m_skillData);
                m_view.DisableSkillItem(sid);
            }
        }
    }
}
