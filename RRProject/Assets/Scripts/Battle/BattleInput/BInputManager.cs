using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BInputManager : MonoBehaviour ,IManager
{
    public BInputModel m_model;
    public BInputView m_view;

    private static BInputManager m_inst;
    public static BInputManager GetInst
    {
        get { return m_inst; }
    }
    public BInputManager()
    {
        m_inst = this;
    }
    

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<BInputModel>("BInputModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<BInputView>("BInputView", this.gameObject);
        m_view.Init(m_model);
    }

    public void StartMgr()
    {

    }

    public void UpdateMgr()
    {
        // 왼쪽
        if (Input.GetKeyDown(KeyCode.D))
            BarManager.GetInst.GetInput(KeyCode.D);
        if (Input.GetKeyDown(KeyCode.A))
            BarManager.GetInst.GetInput(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.S))
            BarManager.GetInst.GetInput(KeyCode.S);
        if (Input.GetKeyDown(KeyCode.W))
            BarManager.GetInst.GetInput(KeyCode.W);
        if (Input.GetKeyDown(KeyCode.E))
            BarManager.GetInst.GetInput(KeyCode.E);
       
        // 오른쪽
        if (Input.GetKeyDown(KeyCode.L))
            BarManager.GetInst.GetInput(KeyCode.L);
        if (Input.GetKeyDown(KeyCode.J))
            BarManager.GetInst.GetInput(KeyCode.J);
        if (Input.GetKeyDown(KeyCode.K))
            BarManager.GetInst.GetInput(KeyCode.K);
        if (Input.GetKeyDown(KeyCode.I))
            BarManager.GetInst.GetInput(KeyCode.I);
        if (Input.GetKeyDown(KeyCode.U))
            BarManager.GetInst.GetInput(KeyCode.U);
    }

    public void GetCombo()
    {
        m_model.ComboSuccess();
        m_view.GetCombo(m_model);
    }
    public void ComboFail()
    {
        m_model.ComboFail();
        m_view.ComboFail(m_model);
    }
    public void GetCommand(KeyCode _code)
    {
        m_view.GetCommand(_code);
    }
    public void CommandFail()
    {
        m_view.CommandFail();
    }

    public void SceneChanged()
    {
    }
}
