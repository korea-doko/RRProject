using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileSpriteType
{
    Normal,
    Obstacle
}
public class MapModel : MonoBehaviour {

    public List<Sprite> m_tileSpriteList;
    public TileData[][] m_tileDataAry;

    public int m_mapWidth;          // 맵 전체 가로 크기
    public int m_mapHeight;         // 맵 전체 세로 크기

    public int m_xMargin;           // 맵 가로 가장 자리 부분
    public int m_yMargin;           // 맵 세로 가장 자리 부분

    public void Init()
    {
        InitVariables();

        InitMap();

        LoadSprite();
    }

    public int GetValidRandomX()
    {
        return UnityEngine.Random.Range(m_xMargin, m_mapWidth - m_xMargin);
    }
    public int GetValidRandomY()
    {
        return UnityEngine.Random.Range(m_yMargin, m_mapHeight - m_yMargin);
    }
    public Sprite GetTileSprite(TileSpriteType _type)
    {
        return m_tileSpriteList[(int)_type];
    }

    void InitVariables()
    {
        m_mapWidth = 40;
        m_mapHeight = 30;

        m_xMargin = 5;
        m_yMargin = 5;

    }
    void InitMap()
    {
        m_tileDataAry = new TileData[m_mapWidth][];

        for (int i = 0; i < m_mapWidth; i++)
            m_tileDataAry[i] = new TileData[m_mapHeight];

        for (int y = 0; y < m_mapHeight; y++)
        {
            for (int x = 0; x < m_mapWidth; x++)
            {
                m_tileDataAry[x][y] = new TileData(x, y);

                if (x < m_xMargin - 1 || x > m_mapWidth - m_xMargin)
                    m_tileDataAry[x][y].SetAsObstacle();

                if (y < m_yMargin - 1 || y > m_mapHeight - m_yMargin)
                    m_tileDataAry[x][y].SetAsObstacle();
            }
        }
    }
    void LoadSprite()
    {
        m_tileSpriteList = new List<Sprite>();

        int numOfSprite = System.Enum.GetNames(typeof(TileSpriteType)).Length;
        
        for(int i = 0; i < numOfSprite;i++)
        {
            Sprite sp = Resources.Load<Sprite>("PlayScene/Images/Tiles/" + ((TileSpriteType)i).ToString());
            m_tileSpriteList.Add(sp);
        }        
    }
}
