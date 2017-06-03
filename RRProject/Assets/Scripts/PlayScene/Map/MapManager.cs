using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour,IManager {

    static MapManager m_inst;
    public static MapManager GetInst
    {
        get { return m_inst; }
    }
    public MapManager()
    {
        m_inst = this;
    }
    public MapModel m_model;
    public MapView m_view;


    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<MapModel>("MapModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<MapView>("MapView", this.gameObject);
        m_view.Init(m_model);
    }
    public void StartMgr()
    {
    
    }
    public void UpdateMgr()
    {

    }

    public TileData GetTileData(int _x,int _y)
    {
        return m_model.m_tileDataAry[_x][_y];
    }
    public Tile GetTile(int _x,int _y)
    {
        return m_view.m_tileAry[_x][_y];
    }
    public void PlayerMoveBy(int _originX, int _originY,int _offsetX,int _offsetY)
    {
        Tile origin = GetTile(_originX, _originY);
        origin.ChangeSprite(m_model.m_tileSprite);

        Tile to = GetTile(_originX + _offsetX, _originY + _offsetY);
        to.ChangeSprite(PlayerManager.GetInst.m_model.m_playerSprite);

        m_view.MapPanelMoveBy(_offsetX, _offsetY);
    }

    public bool IsValidMovePosition(int _x,int _y)
    {
        if (_x >= m_model.m_mapWidth || _x < 0)
            return false;

        if (_y >= m_model.m_mapHeight || _y < 0)
            return false;

        TileData data = GetTileData(_x, _y);

        if (data.m_isObs)
            return false;

        return true;
    }

    public TileData GetValidRandomTileData()
    {
        return GetTileData(m_model.GetValidRandomX(), m_model.GetValidRandomY());
    }
}
