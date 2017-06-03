using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tile : MonoBehaviour
{
    public Image m_image;
    public LayoutElement m_layoutEle;

    public int m_xPos;
    public int m_yPos;

    public void Init(int _xPos, int _yPos)
    {
        m_image = this.GetComponent<Image>();
        m_layoutEle = this.GetComponent<LayoutElement>();
        
        m_xPos = _xPos;
        m_yPos = _yPos;
    }   

    public void ChangeSprite(Sprite _sp)
    {
        m_image.sprite = _sp;
    }


}
