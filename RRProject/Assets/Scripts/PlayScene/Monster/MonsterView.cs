using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterView : MonoBehaviour,IView<MonsterModel> {

    public List<Monster> m_monsterList;

    public void Init(MonsterModel _model)
    {
        InitMonsterList(_model);
    }
    void InitMonsterList(MonsterModel _model)
    {
        m_monsterList = new List<Monster>();

        GameObject monsterPrefab = Resources.Load("PlayScene/Prefabs/Monster") as GameObject;


        for (int i = 0; i < _model.m_numOfMon;i++)
        {
            Monster mon = ((GameObject)Instantiate(monsterPrefab)).GetComponent<Monster>();
            mon.transform.SetParent(this.transform);

            mon.Init(_model.m_monsterDataList[i]);
            m_monsterList.Add(mon);
        }
    }

    public void MonsterMove(MonsterModel _model)
    {
        for(int i = 0; i < m_monsterList.Count;i++)
        {
            MonsterData data = _model.m_monsterDataList[i];
            Monster mon = m_monsterList[i];

            mon.SetParentTile(data.ParentTileData);
        }
    }

    public void UpdateView(MonsterModel _model)
    {
        for(int i = 0; i < _model.m_monsterDataList.Count;i++)
        {
            MonsterData data = _model.m_monsterDataList[i];
            Monster mon = m_monsterList[i];

            if (!data.IsAlive)
                mon.Disable();

            if (data.IsSeen)
                mon.Enable();
            else
                mon.Disable();
        }
    }
}

