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
        int count = PlayToBattleDataPassManager.GetInst.m_monDataList.Count;

        for(int i = 0; i < count;i++)
        {
            BMonsterData bData = m_model.GetEnableData();
            bData.SetData(PlayToBattleDataPassManager.GetInst.m_monDataList[i]);
        }
    }
}
