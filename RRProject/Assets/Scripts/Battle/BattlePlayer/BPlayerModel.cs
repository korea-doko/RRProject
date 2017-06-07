using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPlayerModel : MonoBehaviour
{
    public bool m_isModelChanged;

    public BPlayerData m_playerData;
    
    public void Init()
    {
        m_playerData = new BPlayerData();
        m_isModelChanged = true;
    }
}
