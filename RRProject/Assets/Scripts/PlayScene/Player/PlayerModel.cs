using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSpriteType
{
    Normal
}
public class PlayerModel : MonoBehaviour
{
    public List<Sprite> m_playerSpriteList;

    public PlayerData m_playerData;

    public void Init()
    {
        TileData data = MapManager.GetInst.GetValidRandomTileData();

        m_playerData = new PlayerData(data.m_xIndex,data.m_yIndex);
        

        LoadSprite();
    }    
    public void PlayerMoveBy(int _xOffset, int _yOffset)
    {
        m_playerData.ChangePosIndex(m_playerData.xIndex + _xOffset, m_playerData.yIndex + _yOffset);
    }

    public int PlayerCurXPos
    {
        get { return m_playerData.xIndex; }
    }
    public int PlayerCurYPos
    {
        get { return m_playerData.yIndex; }
    }
        
    void LoadSprite()
    {
        m_playerSpriteList = new List<Sprite>();
        int numOfSprite = System.Enum.GetNames(typeof(PlayerSpriteType)).Length;

        for(int i = 0; i < numOfSprite;i++)
        {
            Sprite sp = Resources.Load<Sprite>("PlayScene/Images/Players/" + ((PlayerSpriteType)i).ToString());
            m_playerSpriteList.Add(sp);
        }
    }
}
