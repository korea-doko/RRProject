using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInputView : MonoBehaviour, IView {

    public Cursor m_cursor;

    public void Init(PlayInputModel _model)
    {
        GameObject cursorPrefab = Resources.Load("PlayScene/Prefabs/Cursor") as GameObject;

        m_cursor = ((GameObject)Instantiate(cursorPrefab)).GetComponent<Cursor>();

        m_cursor.transform.SetParent(this.transform);

        m_cursor.Init(_model.m_cursorData);        
    }
 
    public void UpdateView()
    {

    }

    public void ChangeCursorPos(Vector3 _pos)
    {
        m_cursor.Enable(_pos);
    }
}
