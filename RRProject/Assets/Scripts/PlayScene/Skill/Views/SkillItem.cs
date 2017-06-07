using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour {

    public int m_id;

    public void Init(SkillItemData _data)
    {
        m_id = _data.m_id;
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
