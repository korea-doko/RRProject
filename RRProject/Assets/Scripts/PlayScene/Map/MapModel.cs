using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : MonoBehaviour {

    public TileData[][] m_tileDataAry;

    public int m_mapWidth;          // 맵 전체 가로 크기
    public int m_mapHeight;         // 맵 전체 세로 크기

    public int m_xMargin;           // 맵 가로 가장 자리 부분
    public int m_yMargin;           // 맵 세로 가장 자리 부분


    public float m_tileWidth;       // 타일의 가로 크기
    public float m_tileHeight;      // 타일의 세로 크기

    public int m_playerStartPosX;
    public int m_playerStartPosY;
    // 나중에 이 부분은 다른 곳에서 처리하는게 좋을 것 같다.


    public Sprite m_tileSprite;
    public Sprite m_obsSprite;

    public void Init()
    {
        m_mapWidth = 40;
        m_mapHeight = 30;

        m_tileWidth = 250.0f;
        m_tileHeight = 250.0f;

        m_xMargin = 5;
        m_yMargin = 5;



        m_tileDataAry = new TileData[m_mapWidth][];

        for (int i = 0; i < m_mapWidth; i++)
            m_tileDataAry[i] = new TileData[m_mapHeight];
        
        for(int y = 0; y < m_mapHeight; y++)
        {
            for(int x = 0; x <m_mapWidth;x++)
            {
                m_tileDataAry[x][y] = new TileData(x, y);

                if (x < m_xMargin -1 || x > m_mapWidth - m_xMargin)
                    m_tileDataAry[x][y].SetAsObstacle();

                if (y < m_yMargin -1  || y > m_mapHeight - m_yMargin)
                    m_tileDataAry[x][y].SetAsObstacle();
            }
        }

        m_tileSprite = Resources.Load<Sprite>("PlayScene/Images/Tile");
        m_obsSprite = Resources.Load<Sprite>("PlayScene/Images/Obs");

        m_playerStartPosX = GetValidRandomX();
        m_playerStartPosY = GetValidRandomY();
    }

    public int GetValidRandomX()
    {
        return UnityEngine.Random.Range(m_xMargin, m_mapWidth - m_xMargin);
    }
    public int GetValidRandomY()
    {
        return UnityEngine.Random.Range(m_yMargin, m_mapHeight - m_yMargin);
    }
}
