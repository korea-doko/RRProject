using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public RectTransform m_rect;
    public SensorDir m_dir;
    

    public void Init(SensorData _data)
    {
        m_rect = this.GetComponent<RectTransform>();

        m_rect.anchorMin = new Vector2(0.5f, 0.0f);
        m_rect.anchorMax = new Vector2(0.5f, 1.0f);

        m_dir = _data.m_dir;
        
    }	
}
