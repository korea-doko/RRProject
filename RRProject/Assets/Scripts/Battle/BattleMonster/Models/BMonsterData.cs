﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BMonsterData  {

    public int m_id;
    public bool m_isInit;
    public int m_hp;

	public BMonsterData()
    {
        m_isInit = false;
        m_hp = -1;
    }
    public void SetData(MonsterData _data)
    {
        m_isInit = true;
        m_hp = _data.HP;
        m_id = _data.ID;
    }
    public void Clear()
    {
        m_isInit = false;
    }
}