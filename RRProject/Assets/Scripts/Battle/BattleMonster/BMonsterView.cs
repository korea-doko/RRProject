using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMonsterView : MonoBehaviour , IView<BMonsterModel> {

    public MonsterPanel m_monsterPanel;

    public void Init(BMonsterModel _model)
    {
        m_monsterPanel = GameObject.Find("MonsterPanel").GetComponent<MonsterPanel>();

        m_monsterPanel.Init();
    }

    public void UpdateView(BMonsterModel _model)
    {
        if (_model.m_isModelChanged)
        {
            _model.m_isModelChanged = false;
            for (int i = 0; i < _model.m_bMonsterDataList.Count;i++)
            {
                if (!_model.m_bMonsterDataList[i].m_isInit)
                    break;

                m_monsterPanel.m_text.text = _model.m_bMonsterDataList[i].m_hp.ToString() + "\n"; 
            }
        }
    }
}
