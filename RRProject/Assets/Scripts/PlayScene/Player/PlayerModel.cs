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

    public PlayerData m_playerData;
    public List<ItemData> m_itemList;


    public void Init()
    {
        TileData data = MapManager.GetInst.GetValidRandomTileData();

        m_playerData = new PlayerData(data.m_xIndex,data.m_yIndex);
        m_itemList = new List<ItemData>();
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
    public void GetItem(ItemData _item)
    {
        m_itemList.Add(_item);
    } 
}
