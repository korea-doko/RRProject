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

        m_model.Clear();

        PlayerData pd= DataPassManager.GetInst.m_playToBattleSt.m_playerData;

        BPlayerData bpd = m_model.m_playerData;

        bpd.m_hp = pd.HP;

        for (int i = 0; i < pd.SkillDataList.Count; i++)
        {
            SkillData skd = pd.SkillDataList[i];

            BSkillData bs = BSkillManager.GetInst.GetAvailableBSkillData();
            bs.Init(skd);

            m_model.AddBSkillToBPlayerData(bs);
        }

        // 데이터 변경 및 초기화 끝


        m_view.SceneChanged(m_model);
    }

    public void GetCommand(KeyCode _code , SkillPropertyName _name)
    {
        List<BSkillData> bsl = m_model.m_playerData.m_bSkillDataList;
        int count = bsl.Count;

        for (int i = 0; i < count; i++)
        {
            BSkillData bsd = bsl[i];

            bsd.GetInput(_code,_name);

            if( bsd.CommandCheck())
            {
                // 커맨드 일치, 기술 나가야함
                Debug.Log("입력완성");
                BMonsterManager.GetInst.MonsterGetDamage(7);

            }
        }
    }  
}
