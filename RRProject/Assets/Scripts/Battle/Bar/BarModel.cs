using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BarType
{
    Normal,                 // 안쳐도 손해 x, 그러나 콤보 끊김
    Untouchable,            // 안치면 손해 o, 그리고 콤보 끊김
    Touchable,              // 무효키로 치면 콤보 안끊김, 손해 없음, 나머지 키 누르면 콤보 끊김
}
public enum BarSpriteName
{
    Black,
    Blue,
    Green,
    Red,
    Yellow,
    White
}

public class BarModel : MonoBehaviour
{
    public List<bool[]> m_beatList;

    public bool[] m_leftBeat;
    public bool[] m_rightBeat;

    public int m_indicator;
    
    public List<BarData> m_barDataList;
    public SensorData[] m_sensorDataAry;

    public float m_leftBaseSpeed;
    public float m_rightBaseSpeed;

    public float m_rightBarInterval;
    public float m_leftBarInterval;
    // bar가 어떤 간격으로 나오냐?

    public float m_rightBarPassedTime;
    public float m_leftBarPassedTime;
    // 지나간 시간

    public float m_rightBeatChangeInterval;
    public float m_leftBeatChangeInterval;

    public float m_rightBeatChangeTime;
    public float m_leftBeatChangeTime;

    public float m_BPM;
    
    int m_numOfBarData;

    public void Init()
    {


        m_beatList = new List<bool[]>();

        for(int i = 0; i < 100;i++)
        {
            bool[] newBeat = new bool[12];

            for(int x = 0; x < 12;x++)
            {
                bool beat = UnityEngine.Random.Range(0, 2) == 0 ? true : false;
                newBeat[x] = beat;
            }

            m_beatList.Add(newBeat);
        }

        m_rightBeat = m_beatList[0];
        m_leftBeat = m_beatList[1];

        m_indicator = 0;

        m_rightBeatChangeInterval = UnityEngine.Random.Range(12.0f, 16.0f);
        m_leftBeatChangeInterval = UnityEngine.Random.Range(12.0f, 16.0f);

        m_leftBeatChangeTime = 0.0f;
        m_rightBeatChangeTime = 0.0f;

        InitVariables();
        
        InitBarDataList();
        InitSensorData();
    }
    void InitVariables()
    {
        m_BPM = 140.0f;

        m_numOfBarData = 20;
        m_leftBaseSpeed = 500.0f;
        m_rightBaseSpeed = 500.0f;

        m_rightBarInterval = 60.0f / m_BPM;
        m_rightBarPassedTime = 0.0f;

        m_leftBarInterval = 60.0f / m_BPM;
        m_leftBarPassedTime = 0.0f;

    }
   
    void InitBarDataList()
    {
        m_barDataList = new List<BarData>();

        for (int i = 0; i < m_numOfBarData; i++)
            m_barDataList.Add(new BarData(i));
    }
    void InitSensorData()
    {
        int numOfSensor = System.Enum.GetNames(typeof(SensorDir)).Length;

        m_sensorDataAry = new SensorData[numOfSensor];

        for (int i = 0; i < numOfSensor; i++)
            m_sensorDataAry[i] = new SensorData((SensorDir)i);
    }

    public BarData GetDisabledBarData()
    {
        for(int i= 0; i < m_barDataList.Count;i++)
        {
            if (!m_barDataList[i].m_isActive)
                return m_barDataList[i];           
        }

        Debug.Log("나올 수 없는 지점");
        return null;
    }
    public BarData GetBarData(Bar _bar)
    {
        return m_barDataList[_bar.m_id];
    }
    public SensorData GetSensorData(SensorDir _dir)
    {
        return m_sensorDataAry[(int)_dir];
    }


    public Sprite GetBarSprite(BarSpriteName _barName)
    {
        Sprite sp = ResourceManager.GetInst.GetSprite
            (ResourceType.Bar,(int)_barName);

        return sp;
    }

    public void SceneChanged()
    {
        InitVariables();

        for (int i = 0; i < BMonsterManager.GetInst.m_model.m_monsterDataList.Count; i++)
        {
            MonsterData monData = BMonsterManager.GetInst.m_model.m_monsterDataList[i];

            for (int t = 0; t < monData.GetTitleList.Count; t++)
            {
                TitleData titleData = monData.GetTitleList[t];
               
                //m_rightBaseSpeed =
                //    m_rightBaseSpeed * (100.0f + titleData.m_deltaRightBarSpeed) * 0.01f;

                //m_leftBaseSpeed =
                //    m_leftBaseSpeed * (100.0f + titleData.m_deltaLeftBarSpeed) * 0.01f;
            }
        }

        for (int i = 0; i < m_barDataList.Count;i++)
        {
            BarData d = m_barDataList[i];
            d.Clear();
        }
    }

}
