using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CursorData 
{
    [SerializeField]
    int m_xIndex;
    [SerializeField]
    int m_yIndex;
    [SerializeField]
    Vector3 m_pos;

    public CursorData()
    {
        m_xIndex = PlayerManager.GetInst.m_model.PlayerCurXPos;
        m_yIndex = PlayerManager.GetInst.m_model.PlayerCurYPos;
        m_pos = MapManager.GetInst.GetTilePosWithIndice(m_xIndex, m_yIndex);
    }

    public Vector3 CursorPos
    {
        get { return m_pos; }
        set { m_pos = value; }
    }
    public int XIndex
    {
        get { return m_xIndex; }
        set { m_xIndex = value; }
    }
    public int YIndex
    {
        get { return m_yIndex; }
        set { m_yIndex = value; }
    }
}
