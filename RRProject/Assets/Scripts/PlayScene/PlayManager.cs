﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlaySceneManagerName
{
    PlayInput,
    Skill,
    Map,
    Player      // 맵 보다 늦게 만들어져야 한다.
}

public class PlayManager : MonoBehaviour,IManager{

    private static PlayManager m_inst;
    public PlayManager()
    {
        m_inst = this;
    }

    public IManager[] m_mgrAry;
    public int m_numOfMgr;




    public static PlayManager GetInst
    {
        get { return m_inst; }
    }
    public void AwakeMgr()
    {
        m_numOfMgr = System.Enum.GetNames(typeof(PlaySceneManagerName)).Length;
        m_mgrAry = new IManager[m_numOfMgr];

        for (int i = 0; i < m_numOfMgr; i++)
        {
            string mgrName = ((PlaySceneManagerName)i).ToString() + "Manager";
            GameObject obj = Utils.MakeObjectWithType(mgrName, this.gameObject);
            m_mgrAry[i] = obj.GetComponent<IManager>();

            m_mgrAry[i].AwakeMgr();
        }
    }
    public void StartMgr()
    {
        for (int i = 0; i < m_numOfMgr; i++)
        {
            if (m_mgrAry[i] != null)
                m_mgrAry[i].StartMgr();
        }
    }
    public void UpdateMgr()
    {
        for (int i = 0; i < m_numOfMgr; i++)
        {
            if (m_mgrAry[i] != null)
                m_mgrAry[i].UpdateMgr();
        }
    }

    void Awake()
    {
        AwakeMgr();
    }
    void Start ()
    {
        StartMgr();	
	}
	void Update ()
    {
        UpdateMgr();	
	}

}
