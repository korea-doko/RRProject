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

    
   
    public void AwakeMgr()
    {
     
        
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
                    case BarType.Normal:
                        
                        if( _code != KeyCode.E)
                            BInputManager.GetInst.GetCommand(_code,data.m_skillPropertyName);

                        BInputManager.GetInst.GetCombo();

                        break;
                    case BarType.Touchable:

                        if( _code != KeyCode.E)
                            BInputManager.GetInst.GetCommand(_code);

                        BInputManager.GetInst.GetCombo();
                        
                        break;
                    case BarType.Untouchable:

                        if (_code == KeyCode.E)
                        {
                            BInputManager.GetInst.GetCombo();
                        }
                        else
                        {
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
                    case BarType.Normal:

                        if (_code != KeyCode.U)
                            BInputManager.GetInst.GetCommand(_code,data.m_skillPropertyName);

                        BInputManager.GetInst.GetCombo();

                        break;
                    case BarType.Touchable:

                        if( _code != KeyCode.U)
                            BInputManager.GetInst.GetCommand(_code);

                        BInputManager.GetInst.GetCombo();
                        break;
                    case BarType.Untouchable:

                        if (_code == KeyCode.U)
                        {
                            BInputManager.GetInst.GetCombo();
                        }
                        else
                        {
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
            }
        }
    }
    public void BarPassedSensor(Bar _bar)
    {
        // 바 지나감
        BarData data = m_model.GetBarData(_bar);

        switch (data.m_type)
        {
            case BarType.Normal:
                BInputManager.GetInst.ComboFail();

                break;
            case BarType.Touchable:


                break;
            case BarType.Untouchable:
                BInputManager.GetInst.ComboFail();
                break;
        }
    }

    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {
        m_model.m_rightBarPassedTime += Time.deltaTime;
        m_model.m_leftBarPassedTime += Time.deltaTime;

        if (m_model.m_rightBarPassedTime > m_model.m_rightBarInterval)
                RightBarRegen();

        
        if (m_model.m_leftBarPassedTime > m_model.m_leftBarInterval)
                LeftBarRegen();


        m_model.m_rightBeatChangeTime += Time.deltaTime;
        m_model.m_leftBeatChangeTime += Time.deltaTime;

        if( m_model.m_rightBeatChangeTime > m_model.m_rightBeatChangeInterval)
        {
            m_model.m_rightBeatChangeTime = 0.0f;
            m_model.m_rightBeatChangeInterval = UnityEngine.Random.Range(12.0f, 16.0f);

            int randBeat = UnityEngine.Random.Range(0, m_model.m_beatList.Count);
            m_model.m_rightBeat = m_model.m_beatList[randBeat];

        }

        if ( m_model.m_leftBeatChangeTime > m_model.m_leftBeatChangeInterval)
        {
            m_model.m_leftBeatChangeTime = 0.0f;
            m_model.m_leftBeatChangeInterval = UnityEngine.Random.Range(12.0f, 16.0f);


            int randBeat = UnityEngine.Random.Range(0, m_model.m_beatList.Count);
            m_model.m_leftBeat = m_model.m_beatList[randBeat];
        }

        m_view.UpdateView(m_model);
    }

    public void SceneChanged()
    {
        
        

        m_model.SceneChanged();
        m_view.SceneChanged();
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

        m_model.m_rightBarPassedTime = 0.0f;


        if (!m_model.m_rightBeat[m_model.m_indicator])
        {
            return;
        }
        
        BarData data = m_model.GetDisabledBarData();

        BarType ranType = (BarType)UnityEngine.Random.Range(0, 3);

        data.Activate(ranType, BarDir.Right, m_model.m_rightBaseSpeed);

        m_view.ActivateBar(data);
    }
    void LeftBarRegen()
    {
        m_model.m_leftBarPassedTime = 0.0f;

        int fakeIndicator = m_model.m_indicator;

        m_model.m_indicator++;
        if (m_model.m_indicator > 11)
            m_model.m_indicator = 0;

        if (!m_model.m_leftBeat[fakeIndicator])
        {
            

            return;
        }


        BarData data = m_model.GetDisabledBarData();

        BarType ranType = (BarType)UnityEngine.Random.Range(0, 3);


        data.Activate(ranType,BarDir.Left,m_model.m_leftBaseSpeed);

        m_view.ActivateBar(data);
    }
}
