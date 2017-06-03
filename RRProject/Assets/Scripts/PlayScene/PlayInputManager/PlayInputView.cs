using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInputView : MonoBehaviour {

    public PlayInputViewCursor m_cursor;

    public void Init(PlayInputModel _model)
    {
        GameObject cursorPrefab = Resources.Load("PlayScene/Prefabs/PlayInputViewCursor") as GameObject;

        m_cursor = ((GameObject)Instantiate(cursorPrefab)).GetComponent<PlayInputViewCursor>();

        m_cursor.Init();
    }

    public void SetCursorAt(GameObject _parent)
    {
        m_cursor.Enable(_parent);
    }
}
