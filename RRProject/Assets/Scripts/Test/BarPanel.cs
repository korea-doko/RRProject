using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarPanel : MonoBehaviour
{
    public static BarPanel m_inst;
    public static BarPanel GetInst
    {
        get { return m_inst; }
    }

    public List<Bar> m_rightBarList;
    public List<Bar> m_leftBarList;

    public List<Alarm> m_alarmList;
         
    public GameObject m_rightRegenPoint;
    public GameObject m_leftRegenPoint;
    public GameObject m_alarmPoint;

   
    public float m_rightBarSpeed;
    public float m_leftBarSpeed;

    public float m_rightRegenTime;
    public float m_leftRegenTime;

    public float m_rightPassedTime;
    public float m_leftPassedTime;

    public float m_alarmSpeed;

    public float m_validLen;

    public Text m_commandText;
    public Text m_comboText;

    public int m_comboTextCount;



    //private void Start()
    //{
        
    //    m_inst = this;

    //    m_comboTextCount = 0;

    //    m_rightBarList = new List<Bar>();
    //    m_leftBarList = new List<Bar>();
    //    m_alarmList = new List<Alarm>();

    //    m_rightBarSpeed = 750.0f;
    //    m_rightRegenTime = 1f;

    //    m_leftBarSpeed = 750.0f;
    //    m_leftRegenTime = 1.0f;

    //    m_rightPassedTime = 0.0f;
    //    m_leftPassedTime = 0.0f;

    //    m_alarmSpeed = 100.0f;

    //    m_validLen = 150.0f;

    //    GameObject prefab = Resources.Load("Bar") as GameObject;

    //    for(int i = 0; i < 20;i++)
    //    {
    //        Bar lBar = ((GameObject)Instantiate(prefab)).GetComponent<Bar>();
    //        Bar rBar = ((GameObject)Instantiate(prefab)).GetComponent<Bar>();

    //        lBar.transform.SetParent(this.transform);
    //        rBar.transform.SetParent(this.transform);

    //        lBar.Init();
    //        rBar.Init();

    //        m_leftBarList.Add(lBar);
    //        m_rightBarList.Add(rBar);
    //    }


    //    GameObject alarmPrefab = Resources.Load("Alarm") as GameObject;

    //    for (int i = 0; i < 30;i++)
    //    {
    //        Alarm alarm = ((GameObject)Instantiate(alarmPrefab)).GetComponent<Alarm>();

    //        alarm.transform.SetParent(this.transform);

    //        alarm.Init();

    //        m_alarmList.Add(alarm);
    //    }
    //}

    //private void Update()
    //{
    //    m_rightPassedTime += Time.deltaTime;
    //    m_leftPassedTime += Time.deltaTime;

    //    MoveRightBar();
    //    MoveLeftBar();

    //    if (m_rightPassedTime> m_rightRegenTime)
    //        RightRegenBar();

    //    if (m_leftPassedTime > m_leftRegenTime)
    //        LeftRegenBar();

    //    MoveAlarm();
    //}

    //void MoveRightBar()
    //{
    //    for (int i = 0; i < m_rightBarList.Count; i++)
    //    {
    //        Bar bar = m_rightBarList[i];

    //        if (m_rightBarList[i].m_isActive)
    //        {
    //            bar.m_rect.localPosition += new Vector3(-m_rightBarSpeed * Time.deltaTime, 0, 0);

    //            if (bar.m_rect.localPosition.x < -5.0f)
    //                bar.Disable();
    //        }
    //    }
    //}
    //void MoveLeftBar()
    //{
    //    for (int i = 0; i < m_leftBarList.Count; i++)
    //    {
    //        Bar bar = m_leftBarList[i];

    //        if (m_leftBarList[i].m_isActive)
    //        {
    //            bar.m_rect.localPosition += new Vector3(m_leftBarSpeed * Time.deltaTime, 0, 0);

    //            if (bar.m_rect.localPosition.x > 5.0f)
    //                bar.Disable();
    //        }
    //    }
    //}
    //void RightRegenBar()
    //{
    //    m_rightPassedTime = 0.0f;

    //    for (int i = 0; i < m_rightBarList.Count; i++)
    //    {
    //        Bar bar = m_rightBarList[i];
    //        if (!bar.m_isActive)
    //        {
    //            bar.m_rect.localPosition = m_rightRegenPoint.transform.localPosition;

                
    //            bar.Enable();
    //            break;
    //        }
    //    }
    //}
    //void LeftRegenBar()
    //{
    //    m_leftPassedTime = 0.0f;

    //    for (int i = 0; i < m_leftBarList.Count; i++)
    //    {
    //        Bar bar = m_leftBarList[i];
    //        if (!bar.m_isActive)
    //        {
    //            bar.m_rect.localPosition = m_leftRegenPoint.transform.localPosition;
               
    //            bar.Enable();
    //            break;
    //        }
    //    }
    //}
    //void MoveAlarm()
    //{
    //    for(int i = 0; i < m_alarmList.Count;i++)
    //    {
    //        Alarm al = m_alarmList[i];

    //        if (al.m_isActive)
    //        {
    //            al.m_passedTime += Time.deltaTime;
    //            al.m_rect.transform.localPosition += new Vector3(0, Time.deltaTime * m_alarmSpeed, 0);

    //            if (al.m_passedTime > 1.5f)
    //                al.Disable();
    //        }
    //    }
    //}

    //bool IsValidRightInput()
    //{
    //    for (int i = 0; i < m_rightBarList.Count; i++)
    //    {
    //        Bar bar = m_rightBarList[i];

    //        if (!bar.m_isActive)
    //            continue;

    //        if (bar.m_rect.transform.localPosition.x < m_validLen)
    //            return true;           
    //    }

    //    return false;
    //}
    //bool IsValidLeftInput()
    //{
    //    for (int i = 0; i < m_leftBarList.Count; i++)
    //    {
    //        Bar bar = m_leftBarList[i];

    //        if (!bar.m_isActive)
    //            continue;

    //        if (bar.m_rect.transform.localPosition.x > -m_validLen)
    //            return true;
    //    }

    //    return false;
    //}

    //void Alarm(bool _bool)
    //{
    //    for(int i = 0; i < m_alarmList.Count;i++)
    //    {
    //        Alarm al = m_alarmList[i];

    //        if(!al.m_isActive)
    //        {
    //            al.m_rect.transform.localPosition = m_alarmPoint.transform.localPosition;               
    //            al.Enable(_bool);

    //            break;
    //        }
    //    }
    //}
    //public void Combo(string _name)
    //{
    //    m_comboTextCount++;
    //    if(m_comboTextCount > 8)
    //    {
    //        m_comboTextCount = 0;
    //        m_comboText.text = "Combo :";
    //    }

    //    m_comboText.text += _name + " ";
        
    //}
    //public void KeyDown(KeyCode _code)
    //{
       
    //}
}
