using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData 
{
    public int m_xPos;
    public int m_yPos;

    public bool m_isObs;

    public TileData(int _xPos , int _yPos)
    {
        m_xPos = _xPos;
        m_yPos = _yPos;
        m_isObs = false;
    }
    public void SetAsObstacle()
    {
        m_isObs = true;
    }
}
