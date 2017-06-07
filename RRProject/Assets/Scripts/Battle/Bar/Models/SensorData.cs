using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SensorDir
{
    Right,
    Left
}
[System.Serializable]
public class SensorData
{
    public float m_length;
    public SensorDir m_dir;

    public SensorData( SensorDir _dir, float _len = 150.0f)
    {
        m_dir = _dir;
        m_length = _len;
    }
}
