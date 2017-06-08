using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerManager : MonoBehaviour ,IManager{

    public BPlayerModel m_model;
    public BPlayerView m_view;

    private static BPlayerManager m_inst;
    public static BPlayerManager GetInst
    {
        get { return m_inst; }
    }
    public BPlayerManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<BPlayerModel>("BPlayerModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<BPlayerView>("BPlayerView", this.gameObject);
        m_view.Init(m_model);
    }

    public void StartMgr()
    {

    }

    public void UpdateMgr()
    {
        m_view.UpdateView(m_model);
    }
    public void SceneChanged()
    {
        PlayerData data = DataPassManager.GetInst.m_playToBattleSt.m_playerData;
        m_model.m_playerData.SetData(data);
    }

    public void GetCommand(KeyCode _code , SkillPropertyName _name)
    {
        for (int i = 0; i < m_model.m_playerData.m_skillDataList.Count; i++)
        {
            SkillData sd = m_model.m_playerData.m_skillDataList[i];

            if (sd.CheckCombo(_code, _name))
            {
                // 여기 있다는 것은 스킬이 나가야 한다는 것                
                //sd.Cast();
                BMonsterManager.GetInst.MonsterGetDamage(7);
            }
            
        }
    }
    public void CommandFail()
    {
        for (int i = 0; i < m_model.m_playerData.m_skillDataList.Count; i++)
        {
            SkillData sd = m_model.m_playerData.m_skillDataList[i];
            sd.ClearCombo();
        }
    }
}
