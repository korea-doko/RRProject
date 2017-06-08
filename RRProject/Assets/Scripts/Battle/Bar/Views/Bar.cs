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
        if(_data.m_type == BarType.Normal)
        {
            if (_data.m_skillPropertyName == SkillPropertyName.Black)
                m_image.sprite = BarManager.GetInst.m_model.GetBarSprite(BarSpriteName.Black);
            else if (_data.m_skillPropertyName == SkillPropertyName.Green)
                m_image.sprite = BarManager.GetInst.m_model.GetBarSprite(BarSpriteName.Green);
            else if (_data.m_skillPropertyName == SkillPropertyName.Yellow)
                m_image.sprite = BarManager.GetInst.m_model.GetBarSprite(BarSpriteName.Yellow);
            else
                m_image.sprite = BarManager.GetInst.m_model.GetBarSprite(BarSpriteName.White);
        }
        else if( _data.m_type == BarType.Touchable)
        {
            m_image.sprite = BarManager.GetInst.m_model.GetBarSprite(BarSpriteName.Blue);
        }
        else
        {
            m_image.sprite = BarManager.GetInst.m_model.GetBarSprite(BarSpriteName.Red);
        }

        m_isActive = true;
        this.gameObject.SetActive(m_isActive);
    } 
}
