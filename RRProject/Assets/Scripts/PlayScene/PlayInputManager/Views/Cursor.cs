using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public bool m_isActive;
    

    public void Init(CursorData _data)
    {
        Disable();
    }

    public void Enable(Vector3 _pos)
    {
        this.transform.position = _pos;
        m_isActive = true;
        this.gameObject.SetActive(m_isActive);
    }
    public void Disable()
    {
        m_isActive = false;
        this.gameObject.SetActive(m_isActive);
    }

}
