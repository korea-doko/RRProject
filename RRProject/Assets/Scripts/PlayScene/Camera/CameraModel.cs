using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModel : MonoBehaviour {

    [SerializeField]
    Vector3 m_camPos;

    public Vector3 CamPos
    {
        get { return m_camPos; }
        set { m_camPos = value;
            m_camPos = new Vector3(m_camPos.x, m_camPos.y, -10);
        }
    }

    public void Init()
    {
        Vector3 pos = MapManager.GetInst.GetTilePosWithIndice
            (
            PlayerManager.GetInst.m_model.m_playerData.xIndex,
            PlayerManager.GetInst.m_model.m_playerData.yIndex
            );

        CamPos = pos;
    }
}
