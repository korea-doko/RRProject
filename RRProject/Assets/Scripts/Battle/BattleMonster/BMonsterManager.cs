using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BMonsterManager : MonoBehaviour,IManager {
    
    
    public BMonsterView m_view;
    public BMonsterModel m_model;

    float m_passedTime;

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
        m_passedTime = 0.0f;

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

        m_passedTime += Time.deltaTime;

        if( m_passedTime > 1.0f)
        {
            m_passedTime = 0.0f;

            DamageToPlayer();
            RegenHP();
        }
    }

    public void SceneChanged()
    {
        m_model.SceneChanged();

        MonsterData[] monAry = DataPassManager.GetInst.m_playToBattleSt.m_monsterDataAry;
        int count = monAry.Length;


        for(int i = 0; i < count;i++)
        {
            MonsterData monData = monAry[i];
            m_model.m_monsterDataList.Add(monData);
            
            Debug.Log("몬스터 레벨 = " + monData.Level.ToString());
        }

        m_model.m_isModelChanged = true;
    }
    public void DamageToMonster(int _damage)
    {
        m_model.GetDamage(_damage);
        
        if( m_model.GetMonsterCurHP() < 1)
        {
            // 전투 끝, 플레이 씬으로 돌아가야 한다.
            BattleManager.GetInst.BattleIsOver(true);
        }
    }
    
    void DamageToPlayer()
    {
        int totalDamage = 0;

        for(int i = 0; i < m_model.m_monsterDataList.Count;i++)
            totalDamage += m_model.m_monsterDataList[i].Damage;

        BPlayerManager.GetInst.GetDamaged(totalDamage);
    }
    void RegenHP()
    {
       for(int i = 0; i < m_model.m_monsterDataList.Count;i++)
       {
            MonsterData data = m_model.m_monsterDataList[i];

            if (data.CurHP >= data.HP)
                continue;


            data.CurHP += data.HPRegenRate;

            if (data.CurHP >= data.HP)
                data.CurHP = data.HP;
       }
        m_model.m_isModelChanged = true;
    }
}
