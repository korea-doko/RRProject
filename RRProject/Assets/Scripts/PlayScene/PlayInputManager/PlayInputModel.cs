using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInputModel : MonoBehaviour
{
    public int m_cursorX;
    public int m_cursorY;

    public void Init()
    {
        m_cursorX = 0;
        m_cursorY = 0;
    }

    public void ChangeCursorPosTo(int _x,int _y)
    {
        m_cursorX = _x;
        m_cursorY = _y;
    }
    
}
