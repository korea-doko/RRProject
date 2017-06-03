using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    public MapPanel m_mapPanel;

    public Tile[][] m_tileAry;
    
    public void Init(MapModel _model)
    {
        InitTile(_model);
        InitPanel(_model);
    }

    void InitTile(MapModel _model)
    {
        GameObject tilePrefab = Resources.Load("PlayScene/Prefabs/Tile") as GameObject;
        GameObject tileContainerPrefab = Resources.Load("PlayScene/Prefabs/TileContainer") as GameObject;

        GameObject containerParent = GameObject.Find("MapPanel") as GameObject;

        m_tileAry = new Tile[_model.m_mapWidth][];

        for (int i = 0; i < _model.m_mapWidth; i++)
            m_tileAry[i] = new Tile[_model.m_mapHeight];

        for (int y = _model.m_mapHeight - 1; y > -1; y--)
        {
            GameObject container = Instantiate(tileContainerPrefab) as GameObject;
            container.transform.SetParent(containerParent.transform);

            for (int x = 0; x < _model.m_mapWidth; x++)
            {
                TileData data = _model.m_tileDataAry[x][y];

                m_tileAry[x][y] = ((GameObject)Instantiate(tilePrefab)).GetComponent<Tile>();
                m_tileAry[x][y].Init(x, y);
                m_tileAry[x][y].transform.SetParent(container.transform);

                m_tileAry[x][y].m_layoutEle.preferredHeight = _model.m_tileHeight;
                m_tileAry[x][y].m_layoutEle.preferredWidth = _model.m_tileWidth;

                if( data.m_isObs )
                    m_tileAry[x][y].ChangeSprite(_model.m_obsSprite);                
            }
        }
    }
    void InitPanel(MapModel _model)
    {
        m_mapPanel = GameObject.Find("MapPanel").GetComponent<MapPanel>();

        float width = _model.m_tileWidth * _model.m_mapWidth;
        float height = _model.m_tileHeight * _model.m_mapHeight;


        m_mapPanel.Init(width,height);
    }

    public void MapPanelMoveBy(int _deltaXIndex, int _deltaYIndex)
    {
        float offsetX = MapManager.GetInst.m_model.m_tileWidth * _deltaXIndex;
        float offsetY = MapManager.GetInst.m_model.m_tileHeight * _deltaYIndex;
        m_mapPanel.MoveBy(offsetX,offsetY);
    }
}
