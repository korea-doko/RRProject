using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerView : MonoBehaviour,IView<BPlayerModel>
{
    public PlayerPanel m_playerPanel;
    public SkillPanel m_skillPanel;


	public void Init(BPlayerModel _model)
    {
        m_playerPanel = GameObject.Find("PlayerPanel").GetComponent<PlayerPanel>();
        m_playerPanel.Init();

        m_skillPanel = GameObject.Find("SkillPanel").GetComponent<SkillPanel>();
        m_skillPanel.Init();
    }

    public void UpdateView(BPlayerModel _model)
    { 
        if(_model.m_isModelChanged)
        {
            _model.m_isModelChanged = false;
            m_playerPanel.m_text.text = _model.m_playerData.m_hp.ToString();


            for (int i = 0; i < _model.m_playerData.m_skillDataList.Count; i++)
                m_skillPanel.Show(_model.m_playerData.m_skillDataList[i]);
                

        }
    }
}
