using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 
public class LoadingManager : MonoBehaviour {


    public Button m_btn;
    public Text m_text;
    public float m_progress;

	// Use this for initialization
	void Start ()
    {
        m_btn.interactable = false;
        m_progress = 0.0f;
        m_text.text = m_progress.ToString() + "%";
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if( !m_btn.interactable)
        {
            if( MySceneManager.GetInst.m_isLoadingDone)
            {
                m_text.text = "Loading is done. \n Go to lobby";
                m_btn.interactable = true;
            }
        }
	}

    public void btnclick()
    {
        MySceneManager.GetInst.ChangeScene(SceneName.Lobby);
    }
    public void SceneChanged()
    {

    }
}
