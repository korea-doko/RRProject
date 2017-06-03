using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alarm : MonoBehaviour {

    public RectTransform m_rect;
    public Text m_text;
    public bool m_isActive;

    public float m_passedTime;

    public void Init()
    {
        m_passedTime = 0.0f;
        m_rect = this.GetComponent<RectTransform>();
        m_text = this.GetComponent<Text>();
        Disable();
    }
    public void Enable(bool _bool)       
    {
        m_passedTime = 0.0f;

        
        if ( _bool )
        {            
            m_text.text = "맞음";            
            m_text.color = Color.red;
        }
        else
        {
            m_text.text = "안맞음" ;
            m_text.color = Color.blue;
        }


        m_isActive = true;
        this.gameObject.SetActive(m_isActive);
    }
    public void Disable()
    {
        m_isActive = false;
        this.gameObject.SetActive(m_isActive);
    }
}
