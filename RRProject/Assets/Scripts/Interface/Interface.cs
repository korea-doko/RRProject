using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager
{
    void AwakeMgr();
    void StartMgr();
    void UpdateMgr();

    void SceneChanged();
}
public interface IView
{
    void UpdateView();
}
