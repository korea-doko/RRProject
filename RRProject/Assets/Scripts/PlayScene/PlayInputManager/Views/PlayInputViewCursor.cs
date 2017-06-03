using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInputViewCursor : MonoBehaviour {

    public RectTransform m_rect;
    public void Init()
    {
        m_rect = this.GetComponent<RectTransform>();

        Disable();
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);            
    }
    public void Enable(GameObject _parent)
    {
        this.transform.SetParent(_parent.transform);

        m_rect.anchorMin = Vector2.zero;
        m_rect.anchorMax = Vector2.one;

        m_rect.offsetMax = Vector2.zero;
        m_rect.offsetMin = Vector2.zero;

        this.gameObject.SetActive(true);
    }
}
