using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour ,IView{

    public Camera m_cam;

	public void Init(CameraModel _model)
    {
        m_cam = Camera.main;
        m_cam.transform.SetParent(this.transform);
        m_cam.transform.position = _model.CamPos;

    }
    public void CameraMoveTo(CameraModel _model)
    {
        m_cam.transform.position = _model.CamPos;
    }
    public void UpdateView()
    {

    }
}
