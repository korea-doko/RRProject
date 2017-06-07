using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour,IManager {

    public BarModel m_model;
    public BarView m_view;

    private static BarManager m_inst;
    public static BarManager GetInst
    {
        get { return m_inst; }
    }
    public BarManager()
    {
        m_inst = this;
    }

    public float m_rightBarInterval;
    public float m_leftBarInterval;
    // bar가 어떤 간격으로 나오냐?


    public float m_rightBarPassedTime;
    public float m_leftBarPassedTime;
   
    public void AwakeMgr()
    {
        m_rightBarInterval = 3.0f;
        m_rightBarPassedTime = 0.0f;
        
        m_leftBarInterval = 3.0f;
        m_leftBarPassedTime = 0.0f;
        
        m_model = Utils.MakeObjectWithComponent<BarModel>("BarModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<BarView>("BarView", this.gameObject);
        m_view.Init(m_model);
    }

    public void GetInput(KeyCode _code)
    {
        Bar bar = null;

        // 왼쪽
        if (_code == KeyCode.A || _code == KeyCode.S || _code == KeyCode.D || _code == KeyCode.W || _code == KeyCode.E)
        {
            if ((bar = CheckValidLeftInput()) != null)
            {
                //키가 입력이 확인됐다. 그렇다면 입력된 커맨드, 그리고 타입을 구분해야 한다.

                BarData data = m_model.GetBarData(bar);

                switch (data.m_type)
                {
                    case BarType.White:
                        
                        if( _code != KeyCode.E)
                            BInputManager.GetInst.GetCommand(_code);

                        BInputManager.GetInst.GetCombo();

                        break;
                    case BarType.Red:

                        if( _code != KeyCode.E)
                            BInputManager.GetInst.GetCommand(_code);

                        BInputManager.GetInst.GetCombo();
                        
                        break;
                    case BarType.Blue:

                        if (_code == KeyCode.E)
                        {
                            BInputManager.GetInst.GetCombo();
                        }
                        else
                        {
                            BInputManager.GetInst.CommandFail();
                            BInputManager.GetInst.ComboFail();
                        }
                        break;
                }

                m_view.DeactiveLeftBar(bar);

            }
            else
            {
                // 키 입력했는데 아무것도 없으면 무조건 콤보 실패
                BInputManager.GetInst.ComboFail();
                BInputManager.GetInst.CommandFail();
            }
        }
        
        // 오른쪽
        if (_code == KeyCode.J || _code == KeyCode.K || _code == KeyCode.L || _code == KeyCode.I || _code == KeyCode.U)
        {
            if ((bar = CheckValidRightInput()) != null)
            {
                //키가 입력이 확인됐다. 그렇다면 입력된 커맨드, 그리고 타입을 구분해야 한다.

                BarData data = m_model.GetBarData(bar);

                switch (data.m_type)
                {
                    case BarType.White:

                        if (_code != KeyCode.U)
                            BInputManager.GetInst.GetCommand(_code);

                        BInputManager.GetInst.GetCombo();

                        break;
                    case BarType.Red:

                        if( _code != KeyCode.U)
                            BInputManager.GetInst.GetCommand(_code);

                        BInputManager.GetInst.GetCombo();
                        break;
                    case BarType.Blue:

                        if (_code == KeyCode.U)
                        {
                            BInputManager.GetInst.GetCombo();
                        }
                        else
                        {
                            BInputManager.GetInst.CommandFail();
                            BInputManager.GetInst.ComboFail();
                        }
                        break;
                }
                
                m_view.DeactiveRightBar(bar);               
            }
            else
            {
                // 키 입력했는데 아무것도 없으면 무조건 콤보 실패
                BInputManager.GetInst.ComboFail();
                BInputManager.GetInst.CommandFail();
            }
        }
    }

    public void BarPassedSensor(Bar _bar)
    {
        // 바 지나감
        BarData data = m_model.GetBarData(_bar);

        switch (data.m_type)
        {
            case BarType.White:
                BInputManager.GetInst.ComboFail();
                BInputManager.GetInst.CommandFail();

                break;
            case BarType.Red:


                break;

            case BarType.Blue:
                BInputManager.GetInst.ComboFail();
                BInputManager.GetInst.CommandFail();
                break;
        }
    }


    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {
        m_rightBarPassedTime += Time.deltaTime;
        m_leftBarPassedTime += Time.deltaTime;

        if (m_rightBarPassedTime > m_rightBarInterval)
            RightBarRegen();

        if (m_leftBarPassedTime > m_leftBarInterval)
            LeftBarRegen();



        m_view.UpdateView(m_model);
    }
    public void SceneChanged()
    {

    }
    
    Bar CheckValidRightInput()
    {
        for(int i= 0; i < m_view.m_rightBarList.Count;i++)
        {
            Bar bar = m_view.m_rightBarList[i];

            if( m_view.IsBarOverlapped( BarDir.Right,bar))
                return bar;            
        }
        return null;
    }
    Bar CheckValidLeftInput()
    {
        for(int i = 0; i < m_view.m_leftBarList.Count;i++)
        {
            Bar bar = m_view.m_leftBarList[i];

            if( m_view.IsBarOverlapped(BarDir.Left,bar))
                return bar;            
        }
        return null;
    }

    void RightBarRegen()
    {
        m_rightBarPassedTime = 0.0f;

        BarData data = m_model.GetDisabledBarData();

        data.Activate(BarDir.Right);

        m_view.ActivateBar(data);
    }
    void LeftBarRegen()
    {
        m_leftBarPassedTime = 0.0f;

        BarData data = m_model.GetDisabledBarData();

        data.Activate(BarDir.Left);

        m_view.ActivateBar(data);
    }
}
