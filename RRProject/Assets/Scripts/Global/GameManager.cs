using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GlobalManagerName
{
    MyScene,    
    PlayToBattleDataPass
}
public class GameManager : MonoBehaviour
{
    public int m_numOfMgr;
    public IManager[] m_mgrAry;

	void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);


        m_numOfMgr = System.Enum.GetNames(typeof(GlobalManagerName)).Length;
        m_mgrAry = new IManager[m_numOfMgr];

        for (int i = 0; i < m_numOfMgr; i++)
        {
            string mgrName = ((GlobalManagerName)i).ToString() + "Manager";
            GameObject obj = Utils.MakeObjectWithType(mgrName, this.gameObject);
            m_mgrAry[i] = obj.GetComponent<IManager>();

            m_mgrAry[i].AwakeMgr();
        }
    }
    void Start()
    {
        for (int i = 0; i < m_numOfMgr; i++)
        {
            if (m_mgrAry[i] != null)
                m_mgrAry[i].StartMgr();
        }
    }
    private void Update()
    {
        for (int i = 0; i < m_numOfMgr; i++)
        {
            if (m_mgrAry[i] != null)
                m_mgrAry[i].UpdateMgr();
        }
    }
}
