using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleInputManager : MonoBehaviour ,IManager
{
    public BattleInputModel m_model;
    public BattleInputView m_view;


    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<BattleInputModel>("InputModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<BattleInputView>("InputView", this.gameObject);
        m_view.Init(m_model);
    }

    public void StartMgr()
    {

    }

    public void UpdateMgr()
    {
        if (Input.GetKeyDown(KeyCode.D))
            BarPanel.GetInst.KeyDown(KeyCode.D);
        if (Input.GetKeyDown(KeyCode.A))
            BarPanel.GetInst.KeyDown(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.S))
            BarPanel.GetInst.KeyDown(KeyCode.S);
        if (Input.GetKeyDown(KeyCode.W))
            BarPanel.GetInst.KeyDown(KeyCode.W);
        if (Input.GetKeyDown(KeyCode.L))
            BarPanel.GetInst.KeyDown(KeyCode.L);
        if (Input.GetKeyDown(KeyCode.J))
            BarPanel.GetInst.KeyDown(KeyCode.J);
        if (Input.GetKeyDown(KeyCode.K))
            BarPanel.GetInst.KeyDown(KeyCode.K);
        if (Input.GetKeyDown(KeyCode.I))
            BarPanel.GetInst.KeyDown(KeyCode.I);
    }
    public void SceneChanged()
    {

    }
}
