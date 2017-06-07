using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BarDir
{
    Right,
    Left
}

[System.Serializable]
public class BarData
{
    public int m_id;
    public BarDir m_dir;    
    public bool m_isActive;         // 이 bar 데이터는 현재 움직이고 있는가?
    public float m_speed;
    public BarType m_type;

    public BarData(int _id)
    {
        m_id = _id;
        m_isActive = false;
        m_speed = 100.0f;
        m_type = BarType.White;
    }

    public void Activate(BarDir _dir)
    {
        m_isActive = true;
        m_dir = _dir;
        // 일단 여기서 랜덤으로 주자
        m_type = (BarType)UnityEngine.Random.Range(0, 3);
    }
}
