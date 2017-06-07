using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum SceneName
{
    Loading,
    Lobby,
    Play,
    Battle
}
public class MySceneManager : MonoBehaviour, IManager
{
    
    public SceneName m_curLoadingSceneName;
    public AsyncOperation m_nextAsyncScene;
    public SceneName m_curSceneName;

    public bool m_isLoadingDone;
    
    private static MySceneManager m_inst;
    public static MySceneManager GetInst
    {
        get { return m_inst; }
    }
    public MySceneManager()
    {
        m_inst = this;
    }

    public void AwakeMgr()
    {
        m_curSceneName = SceneName.Loading;
        m_curLoadingSceneName = SceneName.Loading;
        m_nextAsyncScene = null;
        m_isLoadingDone = false;

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }
    public void StartMgr()
    {
        LoadScene(m_curLoadingSceneName);
    }
    public void UpdateMgr()
    {
        if(m_nextAsyncScene != null)
        {
            if( !m_nextAsyncScene.isDone)
            {
                if (m_nextAsyncScene.progress == 0.9f)
                {
                    // 씬 로딩 끝
                    m_nextAsyncScene.allowSceneActivation = true;
                                                
                    m_nextAsyncScene = null;
                }
                else
                {
                    //아직 안됐음
                }
            }
        }
    }
   
    public void LoadScene(SceneName _name)
    {
        m_curLoadingSceneName = _name;

        if (IsSceneAlreadyLoaded(_name))
            return;

        m_nextAsyncScene = SceneManager.LoadSceneAsync(_name.ToString(), LoadSceneMode.Additive);
        m_nextAsyncScene.allowSceneActivation = false;         
    }
    public void ChangeScene(SceneName _name)
    {
        if (!IsSceneAlreadyLoaded(_name))
        {
            LoadScene(_name);
        }
        else
        {
            Scene s = SceneManager.GetActiveScene();
            DisableRootObjs(s);

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);

                if (scene.name == _name.ToString())
                {
                    SceneManager.SetActiveScene(scene);
                    m_curSceneName = _name;

                    EnableRootObjs(scene);

                    break;
                }
            }
        }
    }
    
    void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {

        switch (m_curLoadingSceneName)
        {
            case SceneName.Loading:
                
                LoadScene(SceneName.Lobby);

                break;
            case SceneName.Lobby:


                GameObject[] objs = arg0.GetRootGameObjects();

                for (int i = 0; i < objs.Length; i++)
                    objs[i].SetActive(false);

                LoadScene(SceneName.Battle);

                break;
            case SceneName.Play:

                GameObject[] objss = arg0.GetRootGameObjects();
                
                for (int i = 0; i < objss.Length; i++)
                    objss[i].SetActive(false);

                ChangeScene(SceneName.Play);

                break;
            case SceneName.Battle:

                GameObject[] objs1 = arg0.GetRootGameObjects();

                for (int i = 0; i < objs1.Length; i++)
                    objs1[i].SetActive(false);

                m_isLoadingDone = true;
                break;
            default:
                break;
        }
    }

    bool IsSceneAlreadyLoaded(SceneName _name)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == _name.ToString())
                return true;
        }
        return false;
    }
    void DisableRootObjs(Scene _s)
    {
        GameObject[] obs = _s.GetRootGameObjects();

        for (int i = 0; i < obs.Length; i++)
            obs[i].gameObject.SetActive(false);
    }
    void EnableRootObjs(Scene _s)
    {
        GameObject[] obs = _s.GetRootGameObjects();

        for (int i = 0; i < obs.Length; i++)
            obs[i].gameObject.SetActive(true);

        GameObject rootManager = GameObject.Find(_s.name + "Manager");
        rootManager.SendMessage("SceneChanged");
    }

    public void SceneChanged()
    {

    }
}
