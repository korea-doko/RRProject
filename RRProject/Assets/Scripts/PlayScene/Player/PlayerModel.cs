using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public int m_xPos;
    public int m_yPos;

    public Sprite m_playerSprite;

    public void Init()
    {
        m_xPos = MapManager.GetInst.m_model.m_playerStartPosX;
        m_yPos = MapManager.GetInst.m_model.m_playerStartPosY;

        PlayInputManager.GetInst.m_model.m_cursorX = m_xPos;
        PlayInputManager.GetInst.m_model.m_cursorY = m_yPos;

        m_playerSprite = Resources.Load<Sprite>("PlayScene/Images/Char");
    }    
    public void PlayerMoveBy(int _xOffset, int _yOffset)
    {
        m_xPos += _xOffset;
        m_yPos += _yOffset;
    }
}
