﻿using System;
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


    public void NextTurn()
    {
        int destX = PlayInputManager.GetInst.m_model.GetCursorXIndex;
        int destY = PlayInputManager.GetInst.m_model.GetCursorYIndex;

        PlayerMoveTo(destX, destY);
    }
    public void GetItem(ItemData _data)
    {
        m_model.GetItem(_data);
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
        SkillData skillData = new SkillData(99, "start", 0, "startdesc", new KeyCode[2] { KeyCode.A, KeyCode.K });
        m_model.m_playerData.AddSkillData(skillData);
    }
    public void UpdateMgr()
    {
        m_view.UpdateView();
    }

  
   
    public void SceneChanged()
    {

    }
    void PlayerMoveTo(int _destX, int _destY)
    {
        m_model.m_playerData.ChangePosIndex(_destX, _destY);
        m_view.PlayerMoveTo(_destX, _destY);

        CameraManager.GetInst.CameraMoveTo(_destX, _destY);

        /*
         *  일단 여기서 몬스터가 있는지 검사하고 바로 전투 씬으로 넘기도록 한다. 
         */

        if (MonsterManager.GetInst.CheckMonsterExists(m_model.m_playerData.ParentTileData))
            PlayManager.GetInst.PlayerEncountMonster(m_model.m_playerData);


        ItemManager.GetInst.CheckItemExists(m_model.m_playerData.ParentTileData);

    }

}
