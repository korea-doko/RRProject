using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMonsterManager : MonoBehaviour,IManager {

    public BMonsterView m_view;
    public BMonsterModel m_model;

    private static BMonsterManager m_inst;
    public static BMonsterManager GetInst
    {
        get { return m_inst; }
    }
    public BMonsterManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<BMonsterModel>("BMonterModel", this.gameObject);
        m_model.Init();
            
        m_view = Utils.MakeObjectWithComponent<BMonsterView>("BMonsterView", this.gameObject);
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
        m_model.SceneChanged();

        MonsterData[] monAry = DataPassManager.GetInst.m_playToBattleSt.m_monsterDataAry;
        int count = monAry.Length;

        for(int i = 0; i < count;i++)
        {
            BMonsterData bData = m_model.GetEnableData();
            MonsterData monData = monAry[i];
            bData.SetData(monData);
        }

        m_model.m_isModelChanged = true;
    }

    public void MonsterGetDamage(int _damage)
    {
        m_model.GetDamage(_damage);
        
        if( m_model.GetMonsterHP() < 1)
        {
            // 전투 끝, 플레이 씬으로 돌아가야 한다.
            BattleManager.GetInst.BattleIsOver(true);
        }
    }
}
