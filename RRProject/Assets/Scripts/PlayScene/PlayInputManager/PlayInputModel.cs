using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInputModel : MonoBehaviour
{
    public CursorData m_cursorData;

    public void Init()
    {
        int xindex = PlayerManager.GetInst.m_model.m_playerData.xIndex;
        int yindex = PlayerManager.GetInst.m_model.m_playerData.yIndex;

        m_cursorData = new CursorData();
    }

    public void ChangeCursorPosTo(int _x,int _y)
    {
        m_cursorData.XIndex = _x;
        m_cursorData.YIndex = _y;
    }
    
    public int GetCursorXIndex
    {
        get { return m_cursorData.XIndex; }
        set { m_cursorData.XIndex = value; }
    }
    public int GetCursorYIndex
    {
        get { return m_cursorData.YIndex; }
        set { m_cursorData.YIndex = value; }
    }

}
