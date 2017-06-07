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
        m_model.m_playerData.SetData(PlayToBattleDataPassManager.GetInst.m_playerData);
    }
}
