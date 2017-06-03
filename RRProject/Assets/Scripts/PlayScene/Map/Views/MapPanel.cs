using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : MonoBehaviour {

    public RectTransform m_rect;

    public float m_widht;
    public float m_height;

    public void Init(float _width, float _height)
    {
        m_rect = this.GetComponent<RectTransform>();

        m_widht = _width;
        m_height = _height;

        m_rect.localPosition = new Vector3(m_widht * 0.5f, m_height * 0.5f, 0);

        float offsetToPlayerX = MapManager.GetInst.m_model.m_playerStartPosX * MapManager.GetInst.m_model.m_tileWidth;
        float offsetToPlayerY = MapManager.GetInst.m_model.m_playerStartPosY * MapManager.GetInst.m_model.m_tileHeight;

        MoveBy(offsetToPlayerX, offsetToPlayerY);
    }
    public void MoveBy(float _xOffset, float _yOffset)
    {
        Vector3 pos = m_rect.localPosition - new Vector3(_xOffset, _yOffset, 0);
        m_rect.localPosition = pos;
    }
}
