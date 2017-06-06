using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

    public Camera m_cam;

	public void Init(CameraModel _model)
    {
        Camera[] cam = Camera.allCameras;
        
        for (int i = 0; i < cam.Length; i++)
        {

            if (cam[i].gameObject.layer != LayerMask.NameToLayer("Play"))
                continue;
            
            m_cam = cam[i];
            break;
        }

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
