using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum BattleSceneManagerName
{
    BMonster,
    BPlayer,
    BInput,
    Bar,
    BSkill
}
public class BattleManager : MonoBehaviour ,IManager{

    public bool m_isActivated;

    public static BattleManager GetInst
    {
        get { return m_inst; }
    }
    private static BattleManager m_inst;
    public BattleManager()
    {
        m_inst = this;
    }
   
    public IManager[] m_mgrAry;
    public int m_numOfMgr;

    public void SceneChanged()
    {
        for(int i = 0; i < m_numOfMgr;i++)
        {
            if (m_mgrAry[i] != null)
                m_mgrAry[i].SceneChanged();
        }
        m_isActivated = true;
    }


    public void AwakeMgr()
    {
        m_numOfMgr = System.Enum.GetNames(typeof(BattleSceneManagerName)).Length;
        m_mgrAry = new IManager[m_numOfMgr];

        for (int i = 0; i < m_numOfMgr; i++)
        {
            string mgrName = ((BattleSceneManagerName)i).ToString() + "Manager";
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
        if( m_isActivated )
        {
            for (int i = 0; i < m_numOfMgr; i++)
            {
                if (m_mgrAry[i] != null)
                    m_mgrAry[i].UpdateMgr();
            }
        }
    }


    public void BattleIsOver(bool _isPlayerWin)
    {
        List<BMonsterData> bMonList = BMonsterManager.GetInst.m_model.m_bMonsterDataList;
        BMonsterData[] bMonAry = new BMonsterData[bMonList.Count];
        for (int i = 0; i < bMonList.Count; i++)
            bMonAry[i] = bMonList[i];

        DataPassManager.GetInst.SetBattleToPlayData(_isPlayerWin,bMonAry);
    }

    void Awake()
    {
        AwakeMgr();
    }
    void Start()
    {
        StartMgr();
    }
    void Update()
    {
        UpdateMgr();
    }

}
