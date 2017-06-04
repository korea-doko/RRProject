using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour,IManager{

    private static PlayerManager m_inst;
    public static PlayerManager GetInst
    {
        get { return m_inst; }
    }
    public PlayerManager()
    {
        m_inst = this;
    }

    public PlayerModel m_model;
    public PlayerView m_view;
    

    
    public void PlayerMoveTo(int _destX, int _destY)
    {
        m_model.PlayerCurXPos = _destX;
        m_model.PlayerCurYPos = _destY;

        m_view.PlayerMoveTo(_destX, _destY);

        CameraManager.GetInst.CameraMoveTo(_destX, _destY);
    }


    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<PlayerModel>("PlayerModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<PlayerView>("PlayerView", this.gameObject);
        m_view.Init(m_model);
    }
    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {
        m_view.UpdateView();
    }

}
