﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour,IManager {

    public MonsterModel m_model;
    public MonsterView m_view;

    private static MonsterManager m_inst;
    public static MonsterManager GetInst
    {
        get { return m_inst; }
    }
    public MonsterManager()
    {
        m_inst = this;
    }

    public void NextTurn()
    {
        // change monster pos data
        for (int i = 0; i < m_model.m_monsterDataList.Count;i++)
        {
            MonsterData data = m_model.m_monsterDataList[i];

            int randomAxis = UnityEngine.Random.Range(0, 2);
            
            if( randomAxis == 0)
            {
                int offset = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
                int x = data.xIndex + offset;

                if (MapManager.GetInst.IsValidMoveIndex(x, data.yIndex))
                    data.ChangePosIndex(x, data.yIndex);
            }
            else
            {
                int offset = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
                int y = data.yIndex + offset;

                if (MapManager.GetInst.IsValidMoveIndex(data.xIndex, y))
                    data.ChangePosIndex(data.xIndex, y);
            }
        }

        m_view.MonsterMove(m_model);
    }

    public bool CheckMonsterExists(TileData _data)
    {
        for(int i = 0; i < m_model.m_monsterDataList.Count;i++)
        {
            MonsterData data = m_model.m_monsterDataList[i];
            if (data.ParentTileData.m_xIndex == _data.m_xIndex &&
                data.ParentTileData.m_yIndex == _data.m_yIndex)
            {                
                return true;
            }
        }

        return false;
    }

    public MonsterData GetMonsterData(int _xIndex, int _yIndex)
    {
        for(int i = 0; i < m_model.m_monsterDataList.Count;i++)
        {
            MonsterData data = m_model.m_monsterDataList[i];

            if (data.xIndex == _xIndex && data.yIndex == _yIndex)
                return data;
        }

        return null;
    }
    public MonsterData GetMonsterData(int _id)
    {
        for(int i = 0; i < m_model.m_monsterDataList.Count;i++)
        {
            if (m_model.m_monsterDataList[i].ID == _id)
                return m_model.m_monsterDataList[i];
        }

        Debug.Log("나올 수 없음");
        return null;
    }
    public Monster GetMonster(MonsterData _data)
    {
        for(int i = 0; i < m_view.m_monsterList.Count;i++)
        {
            if (m_view.m_monsterList[i].m_id == _data.ID)
                return m_view.m_monsterList[i];
        }

        Debug.Log("나올 수 없음");
        return null;
    }

    public void AwakeMgr()
    {
      
    }
    public void StartMgr()
    {
        m_model = Utils.MakeObjectWithComponent<MonsterModel>("MonsterModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<MonsterView>("MonsterView", this.gameObject);
        m_view.Init(m_model);
    }
    public void UpdateMgr()
    {
        m_view.UpdateView(m_model);
    }
    public void SceneChanged()
    {
        if (DataPassManager.GetInst.m_battleToPlayST.m_bMonsterDataAry == null)
            return;

        BMonsterData[] bMonAry = DataPassManager.GetInst.m_battleToPlayST.m_bMonsterDataAry;

        for(int i = 0; i < bMonAry.Length;i++)
        {
            BMonsterData bData = bMonAry[i];

            MonsterData data = GetMonsterData(bData.m_id);
            data.ChangeMonsterData(bData);            
        }
    }
}
