using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bar : MonoBehaviour
{
    public RectTransform m_rect;
    public bool m_isActive;
    
    public void Init()
    {
        m_rect = this.GetComponent<RectTransform>();
        m_rect.localPosition = Vector3.zero;
        
        Disable();
    }
    public void Disable()
    {
        m_isActive = false;
        this.gameObject.SetActive(m_isActive);
    }
    public void Enable()
    {
        m_isActive = true;
        this.gameObject.SetActive(m_isActive);
    } 
}
