using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bar : MonoBehaviour
{
    public RectTransform m_rect;
    public Image m_image;

    public bool m_isActive;
    public int m_id;
    public void Init(BarData _data)
    {
        m_id = _data.m_id;
        m_rect = this.GetComponent<RectTransform>();
        m_image = this.GetComponent<Image>();

        m_rect.localPosition = Vector3.zero;
        
        Disable();
    }
    
    public void Disable()
    {
        m_isActive = false;
        this.gameObject.SetActive(m_isActive);
    }
    public void Enable(BarData _data)
    {
        m_image.sprite = BarManager.GetInst.m_model.GetBarSprite(_data.m_type);

        m_isActive = true;
        this.gameObject.SetActive(m_isActive);
    } 
}
