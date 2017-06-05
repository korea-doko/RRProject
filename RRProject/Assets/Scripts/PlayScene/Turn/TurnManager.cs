using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour,IManager {

    public TurnModel m_model;
    public TurnView m_view;

    private static TurnManager m_inst;
    public static TurnManager GetInst
    {
        get { return m_inst; }
    }
    public TurnManager()
    {
        m_inst = this;
    }



    public void NextTurn()
    {
        PlayerManager.GetInst.NextTurn();
        MonsterManager.GetInst.NextTurn();
    }
    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<TurnModel>("TurnModel", this.gameObject);
        m_model.Init();


        m_view = Utils.MakeObjectWithComponent<TurnView>("TurnView", this.gameObject);
        m_view.Init(m_model);
    }
    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {
    }

}
