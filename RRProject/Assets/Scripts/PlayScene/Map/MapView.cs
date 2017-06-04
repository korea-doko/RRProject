using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour, IView
{

    public Tile[][] m_tileAry;
    
    public void Init(MapModel _model)
    {
        InitTile(_model);
    }

    public void UpdateView()
    {

    }

    void InitTile(MapModel _model)
    {
        GameObject tilePrefab = Resources.Load("PlayScene/Prefabs/Tile") as GameObject;
        SpriteRenderer tilePrefabRen = tilePrefab.GetComponent<SpriteRenderer>();

        m_tileAry = new Tile[_model.m_mapWidth][];

        for (int i = 0; i < _model.m_mapWidth; i++)
            m_tileAry[i] = new Tile[_model.m_mapHeight];

        for (int y = _model.m_mapHeight - 1; y > -1; y--)
        {        
            for (int x = 0; x < _model.m_mapWidth; x++)
            {
                TileData data = _model.m_tileDataAry[x][y];

                m_tileAry[x][y] = ((GameObject)Instantiate(tilePrefab)).GetComponent<Tile>();
                m_tileAry[x][y].Init(x, y);
                m_tileAry[x][y].transform.SetParent(this.transform);
                m_tileAry[x][y].transform.position = new Vector3(tilePrefabRen.size.x * x, tilePrefabRen.size.y * y, 0);

                if (data.m_isObs)
                    m_tileAry[x][y].ChangeSprite(_model.GetTileSprite(TileSpriteType.Obstacle));
            }
        }
    }
}
