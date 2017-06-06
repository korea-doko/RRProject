using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Player m_player;

    public void Init(PlayerModel _model)
    {
        GameObject playerPrefab = Resources.Load("PlayScene/Prefabs/Player") as GameObject;

        m_player = ((GameObject)Instantiate(playerPrefab)).GetComponent<Player>();
        m_player.transform.SetParent(this.transform);

        m_player.Init(_model.m_playerData);
    }
   
    public void UpdateView()
    {

    }

    public void PlayerMoveTo(int _destxIndex, int _destyIndex)
    {
        Vector3 destPos = MapManager.GetInst.GetTilePosWithIndice(_destxIndex, _destyIndex);
        m_player.transform.position = destPos;
    }
}
