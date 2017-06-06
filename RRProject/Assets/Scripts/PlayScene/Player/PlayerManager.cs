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
    

    
    

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<PlayerModel>("PlayerModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<PlayerView>("PlayerView", this.gameObject);
        m_view.Init(m_model);
    }
    public void StartMgr()
    {

        SkillData skillData = SkillManager.GetInst.m_model.m_skillDataList[0];
        m_model.m_playerData.AddSkillData(skillData);

    }
    public void UpdateMgr()
    {
        m_view.UpdateView();
    }

    public void NextTurn()
    {
        int destX = PlayInputManager.GetInst.m_model.GetCursorXIndex;
        int destY = PlayInputManager.GetInst.m_model.GetCursorYIndex;

        PlayerMoveTo(destX, destY);
    }

    void PlayerMoveTo(int _destX, int _destY)
    {
        m_model.m_playerData.ChangePosIndex(_destX, _destY);
        m_view.PlayerMoveTo(_destX, _destY);

        CameraManager.GetInst.CameraMoveTo(_destX, _destY);

        /*
         *  일단 여기서 몬스터가 있는지 검사하고 바로 전투 씬으로 넘기도록 한다. 
         */

       if( MonsterManager.GetInst.CheckMonsterExists(m_model.m_playerData.ParentTileData))
            PlayManager.GetInst.PlayerEncountMonster(m_model.m_playerData);

        SkillManager.GetInst.CheckSkillItemExists(m_model.m_playerData.ParentTileData);
            

    }
    public void SceneChanged()
    {

    }
}
