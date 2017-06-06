using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour ,IManager{

    public CameraModel m_model;
    public CameraView m_view;

    private static CameraManager m_inst;
    public static CameraManager GetInst
    {
        get { return m_inst; }
    }
    public CameraManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_model = Utils.MakeObjectWithComponent<CameraModel>("CameraModel", this.gameObject);
        m_model.Init();

        m_view = Utils.MakeObjectWithComponent<CameraView>("CameraView", this.gameObject);
        m_view.Init(m_model);
    }

    public void StartMgr()
    {

    }
    public void UpdateMgr()
    {

    }
    public void CameraMoveTo(int _xTileIndex, int _yTileIndex)
    {
        Vector3 tilePos = MapManager.GetInst.GetTilePosWithIndice(_xTileIndex, _yTileIndex);
        m_model.CamPos = tilePos;

        m_view.CameraMoveTo(m_model);
    }

    public void SceneChanged()
    {

    }
}
