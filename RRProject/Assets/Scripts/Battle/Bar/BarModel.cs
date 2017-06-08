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
    public List<BarData> m_barDataList;
    public SensorData[] m_sensorDataAry;

    public List<Sprite> m_barSpriteList;

    int m_numOfBarData;

    public void Init()
    {
        m_numOfBarData = 20;
        InitSpriteList();
        InitBarDataList();
        InitSensorData();
    }
    void InitSpriteList()
    {
        m_barSpriteList = new List<Sprite>();

        int numOfSpriteType = System.Enum.GetNames(typeof(BarSpriteName)).Length;

        for (int i = 0; i < numOfSpriteType;i++)
        {
            Sprite sp = Resources.Load<Sprite>("BattleScene/Images/" + ((BarSpriteName)i).ToString()+"Bar");
            m_barSpriteList.Add(sp);
        }        
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
        return m_barSpriteList[(int)_barName];
    }
}
