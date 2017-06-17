using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileDir
{
    E,      // 동     0        1,0
    SE,     // 남동   1        1,-1
    S,      // 남     2        0,-1
    SW,     // 남서   3       -1,-1 
    W,      // 서     4       -1,0
    NW,     // 북서   5       -1,1
    N,      // 북     6        0,1
    NE      // 북동   7        1,1
}
public enum TileSpriteType
{
    Normal,
    Obstacle
}


[System.Serializable]
public class Room 
{
    public int m_id;

    public List<Room> m_linkedRoomList;

    public List<RandomMapGenerateData> m_tileList;
    public List<RandomMapGenerateData> m_edgeTileList;
    
    public int m_roomSize;
    public bool m_isMainRoom;
    public bool m_isConnectedToMainRoom;
    

    public Room(int _id)
    {
        m_id = _id;
        m_tileList = new List<RandomMapGenerateData>();
        m_edgeTileList = new List<RandomMapGenerateData>();
        m_linkedRoomList = new List<Room>();
    }
    public void AddGenData(RandomMapGenerateData _data)
    {
        m_roomSize++;
        m_tileList.Add(_data);
    } 
    public void AddEdgeTile(RandomMapGenerateData _data)
    {
        // 이미 들어가 있으면 제외해서 집어넣기

        for(int i = 0; i < m_edgeTileList.Count;i++)
        {
            RandomMapGenerateData inData = m_edgeTileList[i];

            if (_data.m_xIndex == inData.m_xIndex && _data.m_yIndex == inData.m_yIndex)
                return;
        }

        m_edgeTileList.Add(_data);
    }
    public void LinkRoom(Room _room)
    {
        
        if (CheckAlreadyLinkedRoom(_room))
            return;

        if( _room.m_isConnectedToMainRoom )
            SetConnectedToMain();

        m_linkedRoomList.Add(_room);


        _room.LinkRoom(this);
    }

    public void SetConnectedToMain()
    {
        m_isConnectedToMainRoom = true;

        for(int i = 0; i < m_linkedRoomList.Count;i++)
        {
            if (!m_linkedRoomList[i].m_isConnectedToMainRoom)
                m_linkedRoomList[i].SetConnectedToMain();
        }
    }
    public bool CheckAlreadyLinkedRoom(Room _room)
    {
        for(int i = 0; i < m_linkedRoomList.Count;i++)
        {
            if (m_linkedRoomList[i].m_id == _room.m_id)
            {
                //Debug.Log(m_id.ToString() + " 의 방에는 이미 " + m_linkedRoomList[i].m_id.ToString() + "의 방이 링크되어있다");
                return true;
            }
        }

        return false;
    }
    public void Clear()
    {
        for (int i = 0; i < m_tileList.Count; i++)
        {
            RandomMapGenerateData data = m_tileList[i];
            data.m_isWall = true;
        }

        for(int i = 0; i < m_edgeTileList.Count;i++)
        {
            RandomMapGenerateData data = m_edgeTileList[i];
            data.m_isWall = true;
        }

        m_tileList.Clear();
        m_edgeTileList.Clear();
    }
}
[System.Serializable]
public class RandomMapGenerateData
{
    public bool m_isWall;
    public bool m_isDetected;
    
    public int m_xIndex;
    public int m_yIndex;
    

    public RandomMapGenerateData(int _xIndex, int _yIndex)
    {
        m_xIndex = _xIndex;
        m_yIndex = _yIndex;

        m_isWall = false;
        m_isDetected = false;
    }
    public void Clear()
    {
        m_isWall = false;
        m_isDetected = false;
    }
}
[System.Serializable]
public struct Coord2DSt
{
    public int m_x;
    public int m_y;

    public Coord2DSt(int _x, int _y)
    {
        m_x = _x;
        m_y = _y;
    }
}


public struct TestViewSt
{
    public int m_sx;
    public int m_sy;

    public int m_ex;
    public int m_ey;

    public TestViewSt(int _sx, int _sy, int _ex, int _ey)
    {
        m_ex = _ex;
        m_ey = _ey;

        m_sx = _sx;
        m_sy = _sy;
    }
}

public class MapModel : MonoBehaviour {

    public List<Sprite> m_tileSpriteList;

    public TileData[][] m_tileDataAry;

    public List<Room> m_roomList;
    // 방 담아야함
    
    public int m_mapWidth;          // 맵 전체 가로 크기
    public int m_mapHeight;         // 맵 전체 세로 크기

    /// <summary>
    /// 맵 생성 시 사용하는 변수들
    /// </summary>
    [Range(0,100)]
    public int m_fillRate;
    public int m_numOfSmooth;
    public RandomMapGenerateData[][] m_genData;
    public int m_deletRoomSize;
    public Coord2DSt[] m_tileDirOffSet;

    /// <summary>
    /// 테스트
    /// </summary>
    public List<TestViewSt> m_testList;

    public void Init()
    {
        m_testList = new List<TestViewSt>(); 

        LoadSprite();
        InitVariables();


        RegenMap();
    }

    public int GetValidRandomX()
    {
        return UnityEngine.Random.Range(0, m_mapWidth );
    }
    public int GetValidRandomY()
    {
        return UnityEngine.Random.Range(0, m_mapHeight );
    }
    public Sprite GetTileSprite(TileSpriteType _type)
    {
        return m_tileSpriteList[(int)_type];
    }

    public void RegenMap()
    {
        Clear();

        InitTileData();
        SmoothingTileData();
        DetectingRoomsInTileDatas();
        DeleteSmallSizeRooms();
        SetMainRoom();
        
        FindEdgeTileInRooms();
        FindClosestRooms();
        CheckConnectivity();

        // 실제 맵 생성
        InitMap();
    }


    void InitVariables()
    {
        m_mapWidth = 128;
        m_mapHeight = 72;
        // 맵 사이즈

        m_fillRate = 60;
        // 맵을 얼마나 채울 것인가?

        m_numOfSmooth = 5;
        // 맵을 몇 번이나 부드럽게 할 것인가?

        m_deletRoomSize = 50;
        // 너무 작은 방은 삭제하는데 그 사이즈는?

        m_roomList = new List<Room>();
        // 룸 리스트 초기화

        m_genData = new RandomMapGenerateData[m_mapWidth][];

        for (int i = 0; i < m_mapWidth; i++)
            m_genData[i] = new RandomMapGenerateData[m_mapHeight];

        for (int y = 0; y < m_mapHeight; y++)
            for (int x = 0; x < m_mapWidth; x++)
                m_genData[x][y] = new RandomMapGenerateData(x, y);
        // 맵 생성시 사용하는 RandomMapGenrateData 초기화

        m_tileDataAry = new TileData[m_mapWidth][];

        for (int i = 0; i < m_mapWidth; i++)
            m_tileDataAry[i] = new TileData[m_mapHeight];
        // 실제로 사용될 예정인 타일데이터 초기화

        int numOfDir = System.Enum.GetNames(typeof(TileDir)).Length;
        m_tileDirOffSet = new Coord2DSt[numOfDir];

        for (int i = 0; i < numOfDir; i++)
        {
            switch (((TileDir)i))
            {
                case TileDir.E:
                    m_tileDirOffSet[i] = new Coord2DSt(1, 0);
                    break;
                case TileDir.SE:
                    m_tileDirOffSet[i] = new Coord2DSt(1, -1);
                    break;
                case TileDir.S:
                    m_tileDirOffSet[i] = new Coord2DSt(0, -1);
                    break;
                case TileDir.SW:
                    m_tileDirOffSet[i] = new Coord2DSt(-1, -1);
                    break;
                case TileDir.W:
                    m_tileDirOffSet[i] = new Coord2DSt(-1, 0);
                    break;
                case TileDir.NW:
                    m_tileDirOffSet[i] = new Coord2DSt(-1, 1);
                    break;
                case TileDir.N:
                    m_tileDirOffSet[i] = new Coord2DSt(0, 1);
                    break;
                case TileDir.NE:
                    m_tileDirOffSet[i] = new Coord2DSt(1, 1);
                    break;
            }
        }
        // 방향에 대해서 사용할 것 만들어 놨음..
    }
    void InitTileData()
    {                    
        for (int y = 0; y < m_mapHeight; y++)
        {
            for (int x = 0; x < m_mapWidth; x++)
            {
                if (x == 0 || x == m_mapWidth - 1 || y == 0 || y == m_mapHeight- 1)
                    m_genData[x][y].m_isWall = true;
                else
                    m_genData[x][y].m_isWall = Random.Range(0, 100) < m_fillRate ? true : false;
            }
        }        
    }
    void SmoothingTileData()
    {
        bool[][] prevAry = new bool[m_mapWidth][];

        for (int i = 0; i < m_mapWidth; i++)
            prevAry[i] = new bool[m_mapHeight];

        for (int y = 0; y < m_mapHeight; y++)
            for (int x = 0; x < m_mapWidth; x++)
                prevAry[x][y] = m_genData[x][y].m_isWall;

        
        for(int i = 0; i < m_numOfSmooth ;i++)
        {
            for (int y = 0; y < m_mapHeight; y++)
            {
                for (int x = 0; x < m_mapWidth; x++)
                {
                    int neigborCount = GetNeigborCount(prevAry,x, y);

                    m_genData[x][y].m_isWall = neigborCount > 4 ? true : false;
                }
            }

            // Update Prev infos
            for (int y = 0; y < m_mapHeight; y++)
                for (int x = 0; x < m_mapWidth; x++)
                    prevAry[x][y] = m_genData[x][y].m_isWall;
            
        }        
    }
    int GetNeigborCount(bool[][] _prevary,int _xIndex , int _yIndex)
    {
        int neigborCount = 0;
        
        for(int i = 0; i < m_tileDirOffSet.Length;i++)
        {
            Coord2DSt coord = m_tileDirOffSet[i];
            int x = _xIndex + coord.m_x;
            int y = _yIndex + coord.m_y;

            if (IsValidIndex(x,y))
            {
             
                if (_prevary[x][y])
                    neigborCount++;
                
            }
            else
                neigborCount++;
        }      
        
        return neigborCount;
    }
    void DetectingRoomsInTileDatas()
    {

        RandomMapGenerateData startData = GetStartData();
        // 시작하는 놈 찾아옴. 그놈을 확장시킨다.

        Queue<RandomMapGenerateData> queue = new Queue<RandomMapGenerateData>();

        while (true)
        {
            Room room = new Room(m_roomList.Count);

            room.AddGenData(startData);
            queue.Enqueue(startData);
            
            while( queue.Count != 0)
            {
                RandomMapGenerateData data = queue.Dequeue();
                // 가져와서 검사한 다음 큐에 집어넣기

                for (int  i = 0; i < m_tileDirOffSet.Length; i++)
                {
                    Coord2DSt coord = m_tileDirOffSet[i];

                    TileDir dir = (TileDir)i;

                    if (dir == TileDir.NE || dir == TileDir.NW || dir == TileDir.SE || dir == TileDir.SW)
                        continue;


                    int x = data.m_xIndex + coord.m_x;
                    int y = data.m_yIndex + coord.m_y;

                    if (!IsValidIndex(x,y))
                        continue;

                    RandomMapGenerateData genData = m_genData[x][y];

                    if (genData.m_isDetected == true)
                        continue;

                    genData.m_isDetected = true;
                   
                    if (!genData.m_isWall)
                    {
                        room.AddGenData(genData);
                        queue.Enqueue(genData);
                    }
                }
            }

            startData = GetStartData();
            m_roomList.Add(room);
            queue.Clear();

            if (startData == null)
                break;
        }


    }
    RandomMapGenerateData GetStartData()
    {
        for (int y = 0; y < m_mapHeight; y++)
        {
            for (int x = 0; x < m_mapWidth; x++)
            {
                if (!m_genData[x][y].m_isDetected)
                {
                    m_genData[x][y].m_isDetected = true;

                    if (!m_genData[x][y].m_isWall)
                        return m_genData[x][y];
                }
            }
        }

        return null;
    }
    void DeleteSmallSizeRooms()
    {
        for(int i = m_roomList.Count-1; i >=0  ;i--)
        {
            Room room = m_roomList[i];

            if (room.m_roomSize > m_deletRoomSize)
                continue;
            
            room.Clear();
            m_roomList.RemoveAt(i);
        }

        if (m_roomList.Count == 0)
            RegenMap();
    }
    void SetMainRoom()
    {
        int mainRoomID = 0;

        for(int i = 0; i < m_roomList.Count;i++)
        {
            int curMainRoomSize = m_roomList[mainRoomID].m_roomSize;
            int nextRoomSize = m_roomList[i].m_roomSize;

            if( nextRoomSize > curMainRoomSize)
                mainRoomID = i;
            
        }
        Room mainRoom = m_roomList[mainRoomID];
        
        mainRoom.m_isMainRoom = true;
        mainRoom.m_isConnectedToMainRoom = true;

        Debug.Log("MainRoom ID = " + mainRoom.m_id.ToString());

    }
    void FindEdgeTileInRooms()
    {
        for(int i = 0; i < m_roomList.Count;i++)
        {
            Room room = m_roomList[i];
            
            for(int k = 0; k < room.m_tileList.Count;k++)
            {
                RandomMapGenerateData data = room.m_tileList[k];

                for(int q = 0; q < m_tileDirOffSet.Length;q++)
                {
                    TileDir dir = (TileDir)q;

                    if (dir == TileDir.NE || dir == TileDir.NW || dir == TileDir.SE || dir == TileDir.SW)
                        continue;

                    int x = data.m_xIndex + m_tileDirOffSet[q].m_x;
                    int y = data.m_yIndex + m_tileDirOffSet[q].m_y;

                    if (!IsValidIndex(x, y))
                        continue;

                    RandomMapGenerateData expandData = m_genData[x][y];

                    if (!expandData.m_isWall)
                        continue;


                    room.AddEdgeTile(expandData);
                }
            }
        }
    }
    void FindClosestRooms()
    {
     
        if (m_roomList.Count == 1)
            return;

        
        for (int i = 0; i < m_roomList.Count; i++)
        {
            Room baseRoom = m_roomList[i];
            
            if (baseRoom.m_isConnectedToMainRoom && !baseRoom.m_isMainRoom) 
                  continue;
                        
            RandomMapGenerateData tileInBase = null;       
            // 베이스 타일에서 가장 가까운 타일
            RandomMapGenerateData tileInShort =null;
            // 검색된 가장 가까운 방에서 베이스 타일에 가장 가까운 타일

            Room ShortestRoom = GetShortestRoom(baseRoom,out tileInBase, out tileInShort);
            // tileInBase / tielInShort에 값을 할당

            if (ShortestRoom.m_id != baseRoom.m_id)
            {


                m_testList.Add(new TestViewSt(tileInBase.m_xIndex, tileInBase.m_yIndex,
                tileInShort.m_xIndex, tileInShort.m_yIndex));
           


                baseRoom.LinkRoom(ShortestRoom);
            }
        }

        Debug.Log("통로 숫자  ="+ m_testList.Count.ToString());
            
    }
    Room GetShortestRoom(Room _baseRoom,out RandomMapGenerateData _baseTile,
        out RandomMapGenerateData _shortTile)
    {
        Room shortestRoom = _baseRoom;
        float shortestRoomDis = float.MaxValue;

        _baseTile = null;
        _shortTile = null;

        RandomMapGenerateData baseTileData = null;
        RandomMapGenerateData shortTileData = null;

        for (int k = 0; k < m_roomList.Count; k++)
        {
            Room checkRoom = m_roomList[k];

            if (_baseRoom.m_id == checkRoom.m_id)
                continue;

            if (_baseRoom.CheckAlreadyLinkedRoom(checkRoom))
                continue;
            
            float shortestDisBetweenRoom = GetShortestDisBetweenRooms(_baseRoom, checkRoom,
                out baseTileData,out shortTileData);

            if (shortestDisBetweenRoom <= shortestRoomDis)
            {
                shortestRoom = checkRoom;
                shortestRoomDis = shortestDisBetweenRoom;
                _baseTile = baseTileData;
                _shortTile = shortTileData;
            }
        }

        return shortestRoom;
    }
    float GetShortestDisBetweenRooms(Room _baseRoom, Room _targetRoom,
        out RandomMapGenerateData _baseTile, out RandomMapGenerateData _shortTile)
    {
        List<RandomMapGenerateData> baseEdgeList = _baseRoom.m_edgeTileList;
        List<RandomMapGenerateData> checkEdgeList = _targetRoom.m_edgeTileList;

        _baseTile = null;
        _shortTile = null;

        float shortestTileDis = float.MaxValue;

        for (int bel = 0; bel < baseEdgeList.Count; bel++)
        {
            RandomMapGenerateData beld = baseEdgeList[bel];

            for (int cel = 0; cel < checkEdgeList.Count; cel++)
            {
                RandomMapGenerateData celd = checkEdgeList[cel];

                float disX = beld.m_xIndex - celd.m_xIndex;
                float disY = beld.m_yIndex - celd.m_yIndex;

                float tileDis = disX * disX + disY * disY;

                if (tileDis <= shortestTileDis)
                {
                    shortestTileDis = tileDis;
                    _baseTile = beld;
                    _shortTile = celd;
                }
            }
        }

        return shortestTileDis;
    }
    void CheckConnectivity()
    {
        bool isConnectedAll = true;

        for (int i = 0; i < m_roomList.Count; i++)
            if (!m_roomList[i].m_isConnectedToMainRoom)
                isConnectedAll = false;

        if( !isConnectedAll)
        {
            // 다 연결이 안됐으면, 연결을 시켜주자.
            Debug.Log("다 연결이 안되서 추가적으로 연결 확인시켜야한다. 그러나 다시 맵을 만드는 것으로" +
                "바꾸자");

            RegenMap();
        }
    }

    void Clear()
    {
        for (int y = 0; y < m_mapHeight; y++)
            for (int x = 0; x < m_mapWidth; x++)
                m_genData[x][y].Clear();

        for (int i = 0; i < m_roomList.Count; i++)
            m_roomList[i].Clear();

        m_roomList.Clear();

        m_testList.Clear();
    }
    void InitMap()
    {
       
        for (int y = 0; y < m_mapHeight; y++)
        {
            for (int x = 0; x < m_mapWidth; x++)
            {
                m_tileDataAry[x][y] = new TileData(x, y);
                
                if (m_genData[x][y].m_isWall)
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
    bool IsValidIndex(int _xIndex, int _yIndex)
    {
        if (_xIndex < 0 || _xIndex >= m_mapWidth || _yIndex < 0 || _yIndex >= m_mapHeight)
            return false;

        return true;
    }
}