using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInputManager : MonoBehaviour,IManager {

    public PlayInputModel m_model;
    public PlayInputView m_view;


    private static PlayInputManager m_inst;
    public static PlayInputManager GetInst
    {
        get { return m_inst; }
    }
    public PlayInputManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<PlayInputModel>("PlayInputModel",this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<PlayInputView>("PlayInputView", this.gameObject);
        m_view.Init(m_model);
    }

    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {
        //m_view.UpdateView();

        GetInput();         
    }
    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
            GetKeyInput(KeyCode.A);
        else if (Input.GetKeyDown(KeyCode.S))
            GetKeyInput(KeyCode.S);
        else if (Input.GetKeyDown(KeyCode.D))
            GetKeyInput(KeyCode.D);
        else if (Input.GetKeyDown(KeyCode.W))
            GetKeyInput(KeyCode.W);
        else if (Input.GetKeyDown(KeyCode.Space))
            NextTurn();
        else if (Input.GetKeyDown(KeyCode.V))
            RegenMap();
        else if (Input.GetKeyDown(KeyCode.B))
            OnOffFOW();
    }
    void RegenMap()
    {
        MapManager.GetInst.RegenMap();
    }
    void OnOffFOW()
    {
        FOWManager.GetInst.OnOffFOW();
    }
    void GetKeyInput(KeyCode _code)
    {
        int x = m_model.GetCursorXIndex;
        int y = m_model.GetCursorYIndex;

        switch (_code)
        {
            case KeyCode.A:
                x--;
                break;
            case KeyCode.S:
                y--;
                break;
            case KeyCode.D:
                x++;
                break;
            case KeyCode.W:
                y++;
                break;
        }
        

        if (MapManager.GetInst.IsValidMoveIndex(x, y))
        {
            m_model.ChangeCursorPosTo(x, y);
            Vector3 pos = MapManager.GetInst.GetTilePosWithIndice(x, y);
            m_view.ChangeCursorPos(pos);
        }
    }

    void NextTurn()
    {
        TurnManager.GetInst.NextTurn();
    }
    public void SceneChanged()
    {

    }
}
