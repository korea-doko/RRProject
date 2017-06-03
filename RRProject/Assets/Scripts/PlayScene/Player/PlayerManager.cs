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
    

    public void PlayerMoveBy(int _xOffset, int _yOffset)
    {
        MapManager.GetInst.PlayerMoveBy(m_model.m_xPos, m_model.m_yPos, _xOffset, _yOffset);

        m_model.PlayerMoveBy(_xOffset, _yOffset); 
    }
    public void PlayerMoveTo(int _destX, int _destY)
    {
        int offsetX = _destX - m_model.m_xPos;
        int offsetY = _destY - m_model.m_yPos;

        MapManager.GetInst.PlayerMoveBy(m_model.m_xPos, m_model.m_yPos, offsetX, offsetY);
        m_model.PlayerMoveBy(offsetX, offsetY);                
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
        PlayerMoveBy(0, 0);
    }
    public void UpdateMgr()
    {

    }

}
