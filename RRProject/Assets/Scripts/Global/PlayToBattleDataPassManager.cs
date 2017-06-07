using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayToBattleDataPassManager : MonoBehaviour, IManager
{
    public PlayerData m_playerData;
    public List<MonsterData> m_monDataList;

    private static PlayToBattleDataPassManager m_inst;
    public static PlayToBattleDataPassManager GetInst
    {
        get { return m_inst; }
    }
    public PlayToBattleDataPassManager()
    {
        m_inst = this;
    }


    public void AwakeMgr()
    {
        m_playerData = null;
        m_monDataList = new List<MonsterData>();
    }

    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {

    }

    public void SetBattleData(PlayerData _pData, params MonsterData[] _mDatas)
    {
        m_playerData = _pData;
        for (int i = 0; i < _mDatas.Length; i++)
            m_monDataList.Add(_mDatas[i]);


        MySceneManager.GetInst.ChangeScene(SceneName.Battle);
    }
    public void AlarmToBattleManager()
    {

    }

    public void SceneChanged()
    {

    }
}
