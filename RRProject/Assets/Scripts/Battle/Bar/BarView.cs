using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarView : MonoBehaviour, IView<BarModel>
{
    public List<Bar> m_barPoolingList;              // 모든 bar에 대한 정보가 여기에 담겨져 있음.

    public List<Bar> m_rightBarList;                // 오른쪽에서 시작하는 바 리스트
    public List<Bar> m_leftBarList;                 // 왼쪽에서 움직이는 바 리스트

    public Sensor[] m_sensorAry;

    public GameObject m_rightBarRegenPoint;
    public GameObject m_leftBarRegenPoint;

    public void Init(BarModel _model)
    {
        m_rightBarRegenPoint = GameObject.Find("RightBarRegenPoint") as GameObject;
        m_leftBarRegenPoint = GameObject.Find("LeftBarRegenPoint") as GameObject;

        MakeSensor(_model);

        m_rightBarList = new List<Bar>();
        m_leftBarList = new List<Bar>();

        MakePoolingList(_model);
    }
   
    public void UpdateView(BarModel _model)
    {
        MoveLeftBar(_model);
        MoveRightBar(_model);
    }

    public void ActivateBar(BarData _data)
    {
        Bar bar = m_barPoolingList[_data.m_id];

        if (_data.m_dir == BarDir.Left)
        {
            m_leftBarList.Add(bar);
            bar.m_rect.localPosition = m_leftBarRegenPoint.transform.localPosition;
        }
        else
        {
            m_rightBarList.Add(bar);
            bar.m_rect.localPosition = m_rightBarRegenPoint.transform.localPosition;
        }

        bar.Enable(_data);
    }
    
    public void DeactiveLeftBar(Bar _bar)
    {
        BarData data = BarManager.GetInst.m_model.GetBarData(_bar);
        DeactiveLeftBar(_bar, data);
    }
    public void DeactiveLeftBar(Bar _bar, BarData _data)
    {
        _data.m_isActive = false;
        _bar.Disable();
        m_leftBarList.Remove(_bar);
    }

    public void DeactiveRightBar(Bar _bar)
    {
        BarData data = BarManager.GetInst.m_model.GetBarData(_bar);
        DeactiveRightBar(_bar, data);
    }
    public void DeactiveRightBar(Bar _bar, BarData _data)
    {
        _data.m_isActive = false;
        _bar.Disable();
        m_rightBarList.Remove(_bar);
    }

    void DeactiveLeftBarByHit(Bar _bar)
    {
        BarData data = BarManager.GetInst.m_model.GetBarData(_bar);
        DeactiveLeftBar(_bar,data);
    }
    void DeactiveRightBarByHit(Bar _bar)
    {
        BarData data = BarManager.GetInst.m_model.GetBarData(_bar);
        DeactiveRightBar(_bar, data);
    }


    public bool IsBarOverlapped(BarDir _dir, Bar _bar)
    {
        Sensor s = GetSensor(_dir);
        SensorData data = BarManager.GetInst.m_model.GetSensorData(s.m_dir);

        if (s.m_dir == SensorDir.Left)
        {
            if (_bar.m_rect.localPosition.x > -data.m_length)
                return true;
            else
                return false;
        }
        else
        {
            if (_bar.m_rect.localPosition.x < data.m_length)
                return true;
            else
                return false;
        }
    }
    public Sensor GetSensor(BarDir _dir)
    {
        return m_sensorAry[(int)_dir];
    }

    void MakeSensor(BarModel _model)
    {
        m_sensorAry = new Sensor[_model.m_sensorDataAry.Length];

        GameObject sensorParent = GameObject.Find("BarPanel") as GameObject;
        GameObject sensorPrefab = Resources.Load("BattleScene/Prefabs/Sensor") as GameObject;

        for (int i = 0; i < _model.m_sensorDataAry.Length; i++)
        {
            m_sensorAry[i] = ((GameObject)Instantiate(sensorPrefab)).GetComponent<Sensor>();
            m_sensorAry[i].transform.SetParent(sensorParent.transform);

            m_sensorAry[i].Init(_model.m_sensorDataAry[i]);

            if (_model.m_sensorDataAry[i].m_dir == SensorDir.Left)
                m_sensorAry[i].m_rect.pivot = new Vector2(1.0f, 0.5f);
            else
                m_sensorAry[i].m_rect.pivot = new Vector2(0.0f, 0.5f);

            m_sensorAry[i].m_rect.localPosition = Vector3.zero;
            m_sensorAry[i].m_rect.sizeDelta = new Vector2(_model.m_sensorDataAry[i].m_length, 0);
        }
    }
    void MakePoolingList(BarModel _model)
    {
        m_barPoolingList = new List<Bar>();

        GameObject barObj = Resources.Load("BattleScene/Prefabs/Bar") as GameObject;
        GameObject parent = GameObject.Find("BarPanel") as GameObject;

        for (int i = 0; i < _model.m_barDataList.Count; i++)
        {
            Bar bar = ((GameObject)Instantiate(barObj)).GetComponent<Bar>();
            bar.transform.SetParent(parent.transform);

            bar.Init(_model.m_barDataList[i]);
            m_barPoolingList.Add(bar);
        }
    }

    void MoveLeftBar(BarModel _model)
    {
        for (int i = 0; i < m_leftBarList.Count; i++)
        {
            Bar bar = m_leftBarList[i];

            BarData data = _model.m_barDataList[bar.m_id];

            bar.transform.localPosition += new Vector3(data.m_speed * Time.deltaTime, 0, 0);

            if (bar.transform.localPosition.x > 0)
            {
                // 지나간 것
                BarManager.GetInst.BarPassedSensor(bar);
                DeactiveLeftBar(bar, data);
            }
        }
    }
    void MoveRightBar(BarModel _model)
    {
        for (int i = 0; i < m_rightBarList.Count; i++)
        {
            Bar bar = m_rightBarList[i];

            BarData data = _model.m_barDataList[bar.m_id];

            bar.transform.localPosition -= new Vector3(data.m_speed * Time.deltaTime, 0, 0);

            if (bar.transform.localPosition.x < 0)
            {
                BarManager.GetInst.BarPassedSensor(bar);
                DeactiveRightBar(bar, data);
            }
        }
    }

    public void SceneChanged()
    {
        for(int i = 0; i < m_rightBarList.Count;i++)
            m_rightBarList[i].Disable();
        m_rightBarList.Clear();

        for (int i = 0; i < m_leftBarList.Count; i++)
            m_leftBarList[i].Disable();

        m_leftBarList.Clear();

        for (int i = 0; i < m_barPoolingList.Count; i++)
            m_barPoolingList[i].m_isActive = false;
    }
}
